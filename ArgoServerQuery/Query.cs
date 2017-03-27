using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows.Forms;
//--------------------------------------------------------------------------------//
//- QueryMaster is a .NET library to query/control any Source/GoldSource server. -//
//----------------- Find it at https://querymaster.codeplex.com/ -----------------//
//--------------------------------------------------------------------------------//
using QueryMaster;                                                                //
using QueryMaster.GameServer;                                                     //
//--------------------------------------------------------------------------------//

namespace ArgoServerQuery
{
    class Query
    {
        // private static Game appId;
        private const int appId = 730;
        private const int retries = 0;
        private const int timeout = 2500;


        // Helper function to split the address into string-IP and UInt16-port for 
        // using with the server methods
        public static Tuple<string, UInt16> splitAddr(string address)
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

        // This method is used by our background worker to query each server on the 
        // background thread and update the server info in the list
        public static List<Updates> bgUpdater(List<string> addresses)
        {
            List<Updates> results = new List<Updates>();
            string pw = decryptRcon();

            foreach (string address in addresses)
            {
                Tuple<string, UInt16> addr = splitAddr(address);
                string addrIP = addr.Item1;
                string score;
                UInt16 port = addr.Item2;

                using (var server = ServerQuery.GetServerInstance(
                (Game)appId,
                addrIP,
                port,
                throwExceptions: false,
                retries: retries,
                sendTimeout: timeout,
                receiveTimeout: timeout))
                {
                    var serverInfo = server.GetInfo();

                    if (Properties.Settings.Default.disableScore == true)
                    {
                        score = "Disabled";
                        results.Add(new Updates(serverInfo, score));
                    }
                    else if (!String.IsNullOrEmpty(pw))
                    {
                        score = getPugScore(server, pw);
                        results.Add(new Updates(serverInfo, score));
                    }
                    else
                    {
                        score = "No RCON PW";
                        results.Add(new Updates(serverInfo, score));
                    }
                }
            };

            return results;
        }

        // This method is used for general queries
        public static object sendQuery(string address, string pw)
        {

            Tuple<string, UInt16> addr = splitAddr(address);
            string addrIP = addr.Item1;
            string score;
            UInt16 port = addr.Item2;

            using (var server = ServerQuery.GetServerInstance(
                (Game)appId,
                addrIP,
                port,
                throwExceptions: false,
                retries: retries)) {

                var serverInfo = server.GetInfo();

                score = !String.IsNullOrEmpty(pw) ? getPugScore(server, pw) : "Bad RCON PW";

                Updates su = new Updates(serverInfo, score);
                return su;
                // return serverInfo;
            };
        }

        public static string sendRcon(string address, string cmd)
        {
            Tuple<string, UInt16> addr = splitAddr(address);
            string addrIP = addr.Item1;
            UInt16 port = addr.Item2;
            string pw = decryptRcon();
            string startTime = DateTime.Now.ToString("HH:mm:ss");

            var server = ServerQuery.GetServerInstance(
                (Game)appId,
                addrIP,
                port,
                throwExceptions: false,
                retries: retries);

            // GetControl() validates the RCON password and returns true if the server accepts it.
            if (server.GetControl(pw))
            {
                string response = server.Rcon.SendCommand(cmd);
                server.Dispose();
                string endTime = DateTime.Now.ToString("HH:mm:ss");
                string txtOutput = $"{startTime}: {cmd.ToUpper()}\n{response}\n\n";
                return txtOutput;
            }
            else
            {
                server.Dispose();
                return "";
            }
        }

        public static string getPugScore(Server sv, string pw)
        {
            string pugScore;

            // GetControl() validates the RCON password and returns true if the 
            // server accepted it.
            if (sv.GetControl(pw))
            {
                string response = sv.Rcon.SendCommand("getpugscore");
                var splitResp = response.Split('L');
                pugScore = splitResp[0];
            }
            else
            {
                pugScore = "Bad RCON PW.";
            }

            sv.Dispose();
            return pugScore;
        }

        public static JArray getPlayerInfo(string address)
        {
            Tuple<string, UInt16> addr = splitAddr(address);
            string addrIP = addr.Item1;
            UInt16 port = addr.Item2;
            string playerJSON;
            JArray ja;

            var server = ServerQuery.GetServerInstance(
                (Game)appId,
                addrIP,
                port,
                throwExceptions: false,
                retries: retries);

            QueryMasterCollection<PlayerInfo> playerInfo = server.GetPlayers();

            if (playerInfo == null)
            {
                server.Dispose();
                Console.WriteLine("Error fetching player information.");
                return null;
            }
            else
            {
                playerJSON = Convert.ToString(playerInfo);
                ja = JArray.Parse(playerJSON);
                server.Dispose();
                return ja;
            }
        }

        public static string kickPlayer(string address, string player, string reason = "")
        {
            string fullCmd = "";

            if (!String.IsNullOrEmpty(reason))
            {
                fullCmd = $"sm_kick {player} {reason}";
            }
            else if (String.IsNullOrEmpty(reason))
            {
                fullCmd = $"sm_kick {player}";
            }
            
            string response = sendRcon(address, fullCmd);
            return response;
        }

        public static string banPlayerFromServer(string address, string player, string length, string reason = "")
        {
            string fullCmd = "";

            if (!String.IsNullOrEmpty(reason))
            {
                fullCmd = $"sm_banip {player} {length} {reason}";
            }
            else if (String.IsNullOrEmpty(reason))
            {
                fullCmd = $"sm_banip {player} {length}";
            }

            string response = sendRcon(address, fullCmd);
            return response;
        }

        internal static string decryptRcon()
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default.key)
                && !String.IsNullOrEmpty(Properties.Settings.Default.IV)
                && !String.IsNullOrEmpty(Properties.Settings.Default.rconPW))
            {
                try
                {
                    using (RijndaelManaged aesDecrypt = new RijndaelManaged())
                    {
                        aesDecrypt.Key = Convert.FromBase64String(Properties.Settings.Default.key);
                        aesDecrypt.IV = Convert.FromBase64String(Properties.Settings.Default.IV);
                        byte[] encrypted = Convert.FromBase64String(Properties.Settings.Default.rconPW);

                        return PasswordStorage.DecryptStringFromBytes(encrypted, aesDecrypt.Key, aesDecrypt.IV);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                    string message = $"Error attempting to decrypt RCON Info. \n\nINFO: {ex.Message} \n\nSRC: {ex.Source}";
                    string cap = "Error";
                    MessageBoxIcon icon = MessageBoxIcon.Error;
                    MessageBoxButtons btn = MessageBoxButtons.OK;
                    MessageBox.Show(message, cap, btn, icon);
                    return "";
                }
            }

            return null;
        }
    }
}
