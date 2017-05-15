using Ionic.BZip2;
using Ionic.Crc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using QueryMaster;
using ArgoServerQuery.Models;

namespace ArgoServerQuery
{
    internal class UdpQuery : ServerSocket
    {
        private const int SinglePacket = -1;
        private const int MultiPacket = -2;
        private bool isFirstPacket = true;
        private EngineType engineType;

        internal UdpQuery(ConnectionInfo conInfo) : base(conInfo, ProtocolType.Udp)
        {
            Connect(conInfo.EndPoint);
            Socket.SendTimeout = conInfo.SendTimeout;
            Socket.ReceiveTimeout = conInfo.ReceiveTimeout;
        }

        public bool SendFirstPacketTwice { get; set; }

        internal byte[] getResponse(byte[] msg, EngineType type, Stopwatch sw = null)
        {
            engineType = type;
            byte[] recvData = null;
            if (isFirstPacket && SendFirstPacketTwice)
            {
                isFirstPacket = false;
                SendData(msg);
            }
            /*SendData(msg);*/
            /*byte[] data1 = ReceiveData();*/

            try
            {
                sw?.Start();
                SendData(msg);
                recvData = ReceiveData();
                sw?.Stop();
                if (sw != null)
                    Thread.Yield(); // improve accuracy of Ping for other threads

                var header = BitConverter.ToInt32(recvData, 0);
                switch (header)
                {
                    case SinglePacket:
                        return parseSinglePkt(recvData);
                    case MultiPacket:
                        return parseMultiPkt(recvData);
                    default:
                        throw new InvalidHeaderException("Protocol header is not valid");
                }
            }
            catch (Exception e)
            {
                e.Data.Add("ReceivedData", recvData);
                throw;
            }

        /*if (isMultiPacket)
        {
            List<byte> byteList = new List<byte>();
            byteList.AddRange(data1);
            try
            {
                while (true)
                {
                    byte[] data2 = ReceiveData();
                    byteList.AddRange(data2);
                }
            }
            catch (SocketException ex)
            {
                if (ex.SocketErrorCode == SocketError.TimedOut)
                {
                    data1 = byteList.ToArray();
                }
                else
                {
                    Dispose();
                    throw;
                }
            }
        }
        try
        {
            switch (BitConverter.ToInt32(data1, 0))
            {
                case -2:
                    return parseMultiPkt(data1);
                case -1:
                    return parseSinglePkt(data1);
                default:
                    throw new InvalidHeaderException("Protocol header is not valid");
            }
        }
        catch (Exception ex)
        {
            ex.Data.Add("ReceivedData", data1 ?? (new byte[1]));
            Dispose();
            throw;
        }*/
    }

        private byte[] parseSinglePkt(byte[] data)
        {
            return data.Skip(4).ToArray();
        }

        private byte[] parseMultiPkt(byte[] data)
        {
            switch (engineType)
            {
                case EngineType.Source:
                    return SourcePackets(data);
                case EngineType.GoldSource:
                    return GoldSourcePackets(data);
                default:
                    throw new ArgumentException("An invalid EngineType was specified.");
            }
        }

        private byte[] GoldSourcePackets(byte[] data)
        {
            byte[] numArray = null;
            int capacity = data[8] & 15;

            List<KeyValuePair<int, byte[]>> keyValuePairList = new List<KeyValuePair<int, byte[]>>(capacity)
                {
                    new KeyValuePair<int, byte[]>((int) data[8] >> 4, data)
                };

            for (int index = 1; index < capacity; ++index)
            {
                numArray = new byte[BufferSize];
                byte[] data1 = ReceiveData();
                keyValuePairList.Add(new KeyValuePair<int, byte[]>(data1[8] >> 4, data1));
            }

            keyValuePairList.Sort((x, y) => x.Key.CompareTo(y.Key));
            List<byte> source = new List<byte>();
            source.AddRange(keyValuePairList[0].Value.Skip(13));

            for (int index = 1; index < keyValuePairList.Count; ++index)
            {
                source.AddRange(keyValuePairList[index].Value.Skip(9));
            }
            return source.ToArray<byte>();
        }

        private byte[] SourcePackets(byte[] data)
        {
            var pktCount = data[8];
            var pktList = new List<KeyValuePair<byte, byte[]>>(pktCount);
            pktList.Add(new KeyValuePair<byte, byte[]>(data[9], data));

            byte[] recvData;
            for (var i = 1; i < pktCount; i++)
            {
                recvData = ReceiveData();
                pktList.Add(new KeyValuePair<byte, byte[]>(recvData[9], recvData));
            }

            pktList.Sort((x, y) => x.Key.CompareTo(y.Key));
            Parser parser = null;
            var isCompressed = false;
            var checksum = 0;
            var recvList = new List<byte>();
            parser = new Parser(pktList[0].Value);
            parser.SkipBytes(4); // header

            if (parser.ReadInt() < 0) // ID
            {
                isCompressed = true;
            }
            parser.ReadByte(); // total
            int pktId = parser.ReadByte(); // packet id
            parser.ReadUShort(); // size

            if (isCompressed)
            {
                parser.SkipBytes(2); // [this is not equal to decompressed length of data]
                checksum = parser.ReadInt(); // Checksum
            }
            recvList.AddRange(parser.GetUnParsedBytes());

            for (var i = 1; i < pktList.Count; i++)
            {
                parser = new Parser(pktList[i].Value);
                parser.SkipBytes(12); // multipacket header only
                recvList.AddRange(parser.GetUnParsedBytes());
            }
            recvData = recvList.ToArray<byte>();
            if (isCompressed)
            {
                recvData = decompress(recvData);
                if (!isValid(recvData, checksum))
                {
                    throw new InvalidPacketException("packet's checksum value does not match with the calculated checksum");
                }
            }
            return recvData.Skip(4).ToArray();
        }

        private byte[] OldSourcePackets(byte[] data)
        {
            bool flag = false;
            int Checksum = 0;
            byte num1 = data[8];

            List<KeyValuePair<byte, byte[]>> keyValuePairList = new List<KeyValuePair<byte, byte[]>>(num1)
                {
                    new KeyValuePair<byte, byte[]>(data[9], data)
                };

            for (int index = 1; index < num1; ++index)
            {
                byte[] data1 = ReceiveData();
                keyValuePairList.Add(new KeyValuePair<byte, byte[]>(data1[9], data1));
            }
            keyValuePairList.Sort((x, y) => x.Key.CompareTo(y.Key));

            List<byte> source = new List<byte>();
            Parser parser1 = new Parser(keyValuePairList[0].Value);
            parser1.SkipBytes(4);

            if (parser1.ReadInt() < 0)
            {
                flag = true;
            }

            int num2 = parser1.ReadByte();
            int num3 = parser1.ReadByte();
            int num4 = parser1.ReadUShort();

            if (flag)
            {
                parser1.SkipBytes(2);
                Checksum = parser1.ReadInt();
            }

            source.AddRange(parser1.GetUnParsedBytes());

            for (int index = 1; index < keyValuePairList.Count; ++index)
            {
                Parser parser2 = new Parser(keyValuePairList[index].Value);
                parser2.SkipBytes(12);
                source.AddRange(parser2.GetUnParsedBytes());
            }

            byte[] data2 = source.ToArray<byte>();
            if (flag)
            {
                data2 = decompress(data2);
                if (!isValid(data2, Checksum))
                {
                    throw new InvalidPacketException("packet's checksum value does not match with the calculated checksum");
                }
            }
            return data2.Skip(4).ToArray();
        }

        private byte[] decompress(byte[] data)
        {
            using (var input = new MemoryStream(data))
            {
                using (var output = new MemoryStream())
                {
                    using (var unZip = new BZip2InputStream(input))
                    {
                        var ch = unZip.ReadByte();

                        while (ch != -1)
                        {
                            output.WriteByte((byte)ch);
                            ch = unZip.ReadByte();
                        }
                        output.Flush();
                        return output.ToArray();
                    }
                }
            }
        }

        private bool isValid(byte[] data, int Checksum)
        {
            using (MemoryStream memoryStream = new MemoryStream(data))
            {
                return Checksum == new CRC32().GetCrc32(memoryStream);
            }
        }
    }
}
