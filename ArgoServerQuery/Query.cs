using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using QueryMaster;
using QueryMaster.GameServer;

namespace ArgoServerQuery
{
    class Query
    {
        // private static Game appId;
        static int appId = 730;
        static int retries = 0;


        // Helper function to split the address into string-IP and UInt16-port for 
        // using with the server methods
        public static Tuple<string, UInt16> splitAddr(string address)
        {

            string[] split = address.Split(':');
            if (split.Length != 2)
            {
                // Could be just one part, or more than 2...
                // throw an exception or whatever
            }
            string hostIP = split[0];
            ushort hostPort = Convert.ToUInt16(split[1]);

            return Tuple.Create(hostIP, hostPort);

        }


        // This method is used by our background worker to query each server on the 
        // background thread and update the server info in the list
        public static object sendQuery(string address)
        {

            Tuple<string, UInt16> addr = splitAddr(address);
            string addrIP = addr.Item1;
            UInt16 port = addr.Item2;

            using (var server = ServerQuery.GetServerInstance(
                (Game)appId, 
                addrIP, 
                port, 
                throwExceptions: false, 
                retries: retries)) {

                var serverInfo = server.GetInfo();
                return serverInfo;
            };
        }


        public static string sendRcon(string address, string cmd, string pw)
        {

            Tuple<string, UInt16> addr = splitAddr(address);
            string addrIP = addr.Item1;
            UInt16 port = addr.Item2;
            string response;
            string separator = string.Format("{0}-----{0}", Environment.NewLine);

            var server = ServerQuery.GetServerInstance(
                (Game)appId,
                addrIP,
                port,
                throwExceptions: false,
                retries: retries);

            // GetControl() validates the RCON password and returns true if the 
            // server accepted it.
            if (server.GetControl(pw))
            {
                response = server.Rcon.SendCommand(cmd);
            }
            else
            {
                response = "Invalid RCON Password.";
            }

            server.Dispose();
            return response + separator;
        }
    }
}
