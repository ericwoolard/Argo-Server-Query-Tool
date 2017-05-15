using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QueryMaster;

namespace ArgoServerQuery
{
    internal class Parser
    {
        private int currentPosition;
        private byte[] Data;
        private int lastPosition;

        internal bool HasUnParsedBytes
        {
            get
            {
                return this.currentPosition <= this.lastPosition;
            }
        }

        internal Parser(byte[] data)
        {
            this.Data = data;
            this.currentPosition = -1;
            this.lastPosition = this.Data.Length - 1;
        }

        internal byte ReadByte()
        {
            ++currentPosition;
            if (currentPosition > lastPosition)
            {
                throw new ParseException("Index was outside the bounds of the byte array.");
            }

            return Data[currentPosition];
        }

        internal ushort ReadUShort()
        {
            currentPosition++;
            if (currentPosition + 3 > lastPosition)
            {
                throw new ParseException("Unable to parse bytes to ushort.");
            }
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(Data, currentPosition, 2);
            }
            ushort uint16 = BitConverter.ToUInt16(Data, currentPosition);
            currentPosition++;
            return uint16;
        }

        internal int ReadInt()
        {
            currentPosition++;
            if (currentPosition + 3 > lastPosition)
            {
                throw new ParseException("Unable to parse bytes to int.");
            }
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(Data, currentPosition, 4);
            }
            int int32 = BitConverter.ToInt32(Data, currentPosition);
            currentPosition += 3;
            return int32;
        }

        internal ulong ReadULong()
        {
            ++currentPosition;
            if (currentPosition + 7 > lastPosition)
            {
                throw new ParseException("Unable to parse bytes to ulong.");
            }
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(Data, currentPosition, 8);
            }
            ulong uint64 = BitConverter.ToUInt64(Data, currentPosition);
            currentPosition += 7;
            return uint64;
        }

        internal float ReadFloat()
        {
            ++currentPosition;
            if (currentPosition + 3 > lastPosition)
            {
                throw new ParseException("Unable to parse bytes to float.");
            }
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(Data, currentPosition, 4);
            }
            float single = BitConverter.ToSingle(Data, currentPosition);
            currentPosition += 3;
            return single;
        }

        internal string ReadString()
        {
            currentPosition++;
            int intCurrentPosition = currentPosition;
            while (Data[currentPosition] != 0)
            {
                currentPosition++;
                if (currentPosition > lastPosition)
                {
                    throw new ParseException("Unable to parse bytes to string.");
                }
            }
            return Encoding.UTF8.GetString(Data, intCurrentPosition, currentPosition - intCurrentPosition);
        }

        internal void SkipBytes(byte count)
        {
            currentPosition += count;
            if (currentPosition > lastPosition)
            {
                throw new ParseException("skip count was outside the bounds of the byte array.");
            }
        }

        internal byte[] GetUnParsedBytes()
        {
            return Data.Skip(currentPosition + 1).ToArray();
        }
    }
}
