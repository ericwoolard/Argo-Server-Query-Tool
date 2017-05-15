using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using ArgoServerQuery.Models;
using Newtonsoft.Json;
//--------------------------------------------------------------------------------//
//- QueryMaster is a .NET library to query/control any Source/GoldSource server. -//
//----------------- Find it at https://querymaster.codeplex.com/ -----------------//
//--------------------------------------------------------------------------------//
using QueryMaster;                                                                //
using QueryMaster.GameServer;                                                     //
//--------------------------------------------------------------------------------//

namespace ArgoServerQuery
{
    public class Query
    {
        // private static Game appId;
        private const int appId = 730;
        private const int retries = 0;
        private const int timeout = 400;
        private static int rconFailCount = 0;


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
        public static List<UpdatesModel> bgUpdater(List<string> addresses)
        {
            List<UpdatesModel> results = new List<UpdatesModel>();
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
                retries: 0,
                sendTimeout: timeout,
                receiveTimeout: timeout))
                {
                    var serverInfo = server.GetInfo();

                    // If score check is disabled, skip it
                    if (Properties.Settings.Default.disableScore)
                    {
                        score = "Disabled";
                        results.Add(new UpdatesModel(serverInfo, score));
                    }
                    else if (!String.IsNullOrEmpty(pw))
                    {
                        if (rconFailCount < 1)
                        {
                            score = getPugScore(server, pw);
                            if (score.Contains("Bad"))
                            {
                                score = "Bad password..";
                                Console.WriteLine("Bad pass..");
                                rconFailCount++;
                                results.Add(new UpdatesModel(serverInfo, score));
                            }
                            else
                            {
                                results.Add(new UpdatesModel(serverInfo, score));
                            }
                        }
                        else if (rconFailCount > 0)
                        {
                            Properties.Settings.Default.disableScore = true;
                            Properties.Settings.Default.Save();
                            score = "Disabled.";
                            results.Add(new UpdatesModel(serverInfo, score));
                            rconFailCount = 0;
                        }
                    }
                    else
                    {
                        score = "No RCON PW";
                        results.Add(new UpdatesModel(serverInfo, score));
                    }
                }
            }

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

                UpdatesModel su = new UpdatesModel(serverInfo, score);
                return su;
                // return serverInfo;
            }
        }

        public static string sendRcon(string address, string cmd)
        {
            Tuple<string, UInt16> addr = splitAddr(address);
            string addrIP = addr.Item1;
            UInt16 port = addr.Item2;
            string pw = decryptRcon();

            var server = ServerQuery.GetServerInstance(
                (Game)appId,
                addrIP,
                port,
                throwExceptions: false,
                retries: retries,
                sendTimeout: 2000,
                receiveTimeout: 2000);

            try
            {
                // GetControl() validates the RCON password and returns true if the 
                // server accepted it. For some reason this only works half of the time..
                if (server.GetControl(pw))
                {
                    string response = server.Rcon.SendCommand(cmd);
                    server.Dispose();
                    return response;
                }
                server.Dispose();
                return null;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
            } 
        }

        public static string sendStatus(string address, string cmd)
        {
            Tuple<string, UInt16> addr = splitAddr(address);
            string addrIP = addr.Item1;
            UInt16 port = addr.Item2;
            string pw = decryptRcon();

            var server = ServerQuery.GetServerInstance(
                (Game)appId,
                addrIP,
                port,
                throwExceptions: false,
                retries: retries,
                sendTimeout: 2000,
                receiveTimeout: 2000);

            try
            {
                // GetControl() validates the RCON password and returns true if the 
                // server accepted it. For some reason this only works half of the time..
                if (server.GetControl(pw))
                {
                    string response = server.Rcon.SendCommand(cmd);
                    server.Dispose();
                    if (String.IsNullOrEmpty(response)) { return null; }

                    return response;
                }
                server.Dispose();
                return null;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
            }
        }

        private static string getPugScore(Server sv, string pw)
        {
            string pugScore;
            if (sv.GetControl(pw))
            {
                try
                {
                    string response = sv.Rcon.SendCommand("getpugscore");
                    var splitResp = response.Split('L');
                    pugScore = splitResp[0];
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine(ex);
                    pugScore = "Error";
                }
            }
            else
            {
                pugScore = "Bad RCON PW.";
            }

            sv.Dispose();
            return pugScore;
        }

        // getPlayerInfo() retrieves a player list grouped by team and includes
        // each players Kill/Death ratio.
        public static JArray getPlayerInfo(string address)
        {
            Tuple<string, UInt16> addr = splitAddr(address);
            string addrIP = addr.Item1;
            UInt16 port = addr.Item2;

            var server = ServerQuery.GetServerInstance(
                (Game)appId,
                addrIP,
                port,
                throwExceptions: false,
                retries: retries);

            sendRcon(address, "host_players_show 2");
            //QueryMasterCollection<PlayerInfo> playerInfo = server.GetPlayers();
            string playerInfo = sendRcon(address, "getplayers");
            sendRcon(address, "host_players_show 1");

            if (playerInfo == null || playerInfo.Contains("Unknown"))
            {
                server.Dispose();
                Console.WriteLine("Error fetching player information.");
                return null;
            }

            List<PlayerModel> playerList_T = new List<PlayerModel>();
            List<PlayerModel> playerList_CT = new List<PlayerModel>();

            using (StringReader reader = new StringReader(playerInfo))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] splitter = line.Split(':');
                    switch (splitter[1])
                    {
                        case "T":
                            playerList_T.Add(new PlayerModel(splitter[0], splitter[1], splitter[2], splitter[3]));
                            break;
                        case "CT":
                            playerList_CT.Add(new PlayerModel(splitter[0], splitter[1], splitter[2], splitter[3]));
                            break;
                    }
                }
            }
            var playerJsonStr_T = JsonConvert.SerializeObject(playerList_T, Formatting.Indented);
            var playerJsonStr_CT = JsonConvert.SerializeObject(playerList_CT, Formatting.Indented);

            var jaT = (JArray)JsonConvert.DeserializeObject(playerJsonStr_T);
            var jaCT = (JArray)JsonConvert.DeserializeObject(playerJsonStr_CT);
            var jaBothTeams = new JArray(jaT, jaCT);

            server.Dispose();
            return jaBothTeams;
        }

        // Same as sendRcon() minus a slightly longer timeout and the ping test
        public static string rcon2All(string address, string cmd)
        {
            Tuple<string, UInt16> addr = splitAddr(address);
            string addrIP = addr.Item1;
            UInt16 port = addr.Item2;
            string pw = decryptRcon();

            var server = ServerQuery.GetServerInstance(
                (Game)appId,
                addrIP,
                port,
                throwExceptions: false,
                retries: retries,
                sendTimeout: 2000,
                receiveTimeout: 2000);

            try
            {
                if (server.GetControl(pw))
                {
                    // Ping test to make sure the server is online (-1 if timeout)
                    long pingTest = server.Ping();
                    if (pingTest == -1)
                    {
                        return null;
                    }
                    string response = server.Rcon.SendCommand(cmd);
                    server.Dispose();
                    return " " + response;
                }
                server.Dispose();
                return null;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
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
            string fullCmd;
            string response;

            if (String.IsNullOrEmpty(reason))
            {
                fullCmd = $"sm_ban {player} {length}";
                response = rcon2All(address, fullCmd);
                return response;
            }

            fullCmd = $"sm_ban {player} {length} {reason}";
            response = rcon2All(address, fullCmd);
            return response;
        }

        public static ReadOnlyCollection<RulesModel> getServerRules(string address)
        {
            Tuple<string, UInt16> addr = splitAddr(address);
            string addrIP = addr.Item1;
            UInt16 port = addr.Item2;
            string pw = decryptRcon();

            var server = ServerQuery.GetServerInstance(
                (Game)appId,
                addrIP,
                port,
                throwExceptions: false,
                retries: retries,
                sendTimeout: 2000,
                receiveTimeout: 2000);

            try
            {
                if (server.GetControl(pw))
                {
                    //var rules = server.GetRules(x => Console.WriteLine("Fetching Server Rules, Attempt " + x));
                    Rules rulesInstance = new Rules(server);
                    ReadOnlyCollection<RulesModel> rules = rulesInstance.GetRules();
                    server.Dispose();
                    if (rules.Count > 0)
                    {
                        return rules;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
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
