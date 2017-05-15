using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using QueryMaster;
using ArgoServerQuery.Models;

namespace ArgoServerQuery
{
    internal class ServerSocket : QueryMasterBase
    {
        internal static readonly int UdpBufferSize = 1400;
        internal static readonly int TcpBufferSize = 4110;
        private readonly object LockObj = new object();
        internal IPEndPoint Address;
        protected internal int BufferSize;
        protected bool IsDisposed;
        private readonly byte[] recvData;

        internal EngineType EngineType { get; set; }

        internal Socket Socket { get; set; }

        internal ServerSocket(ConnectionInfo conInfo, ProtocolType type)
        {
            switch (type)
            {
                case ProtocolType.Tcp:
                    Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    BufferSize = ServerSocket.TcpBufferSize;
                    break;
                case ProtocolType.Udp:
                    Socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    BufferSize = ServerSocket.UdpBufferSize;
                    break;
                default:
                    throw new ArgumentException("An invalid SocketType was specified.");
            }
            this.Socket.SendTimeout = conInfo.SendTimeout;
            this.Socket.ReceiveTimeout = conInfo.ReceiveTimeout;
            /*this.Address = conInfo.EndPoint;*/

            /*if (!this.Socket.BeginConnect(this.Address, (AsyncCallback)null, null)
                .AsyncWaitHandle.WaitOne(conInfo.ReceiveTimeout, true))
            {
                throw new SocketException(10060);
            }*/
            recvData = new byte[BufferSize];
            IsDisposed = false;
        }

        internal void Connect(IPEndPoint address)
        {
            Address = address;
            Socket.Connect(Address);
        }

        internal int SendData(byte[] data)
        {
            ThrowIfDisposed();
            lock (LockObj)
            {
                return Socket.Send(data);
            }
        }

        internal byte[] ReceiveData()
        {
            var recv = Socket.Receive(recvData);
            var data = new byte[recv];
            Array.Copy(recvData, 0, data, 0, recv);
            return data;


            /*ThrowIfDisposed();
            byte[] buffer = new byte[BufferSize];

            int count = 0;
            lock (LockObj)
            {
                count = Socket.Receive(buffer);
            }
            return buffer.Take(count).ToArray();*/
        }

        protected override void Dispose(bool disposing)
        {
            if (IsDisposed) return;

            if (disposing)
            {
                lock (LockObj)
                {
                    Socket?.Close();
                }
            }
            base.Dispose(disposing);
            IsDisposed = true;
        }
    }
}
