using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using QueryMaster;
using QueryMaster.GameServer;

namespace ArgoServerQuery
{
    public class PingCheck
    {
        private List<string> addresses { get; }

        public PingCheck(List<string> addrList)
        {
            this.addresses = addrList;
        }

        public List<int> sendCheck()
        {
            List<int> failedChecks = new List<int>();
            foreach (string address in addresses)
            {
                Tuple<string, UInt16> addr = splitAddr(address);
                string addrIP = addr.Item1;
                UInt16 port = addr.Item2;

                using (var server = ServerQuery.GetServerInstance(
                    (Game) 730,
                    addrIP,
                    port,
                    throwExceptions: false,
                    retries: 2,
                    sendTimeout: 600,
                    receiveTimeout: 600))
                {
                    try
                    {
                        var ping = server.Ping();
                        if (ping == -1)
                        {
                            failedChecks.Add(addresses.IndexOf(address));
                        }
                    }
                    catch (SocketException e)
                    {
                        failedChecks.Add(addresses.IndexOf(address));
                    }
                }
            }
            if (failedChecks.Count != 0) return failedChecks;
            failedChecks.Add(-1);
            return failedChecks;
        }

        private static Tuple<string, UInt16> splitAddr(string address)
        {
            string[] split = address.Split(':');
            if (split.Length != 2)
            {
                throw new FormatException("Invalid address");
            }
            else
            {
                string hostIP = split[0];
                ushort hostPort = Convert.ToUInt16(split[1]);

                return Tuple.Create(hostIP, hostPort);
            }
        }
    }
}
