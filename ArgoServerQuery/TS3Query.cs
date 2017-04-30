using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;
//-------------------------------------------------------------------------------//
//- TS3QueryLib is a type safe library for querying over the server query port. -//
//-------- TS3QueryLib can be found at https://ts3querylib.codeplex.com/ --------//
//-------------------------------------------------------------------------------//
using TS3QueryLib.Core;                                                          //
using TS3QueryLib.Core.Common.Responses;                                         //
using TS3QueryLib.Core.Server;                                                   //
using TS3QueryLib.Core.Server.Entities;                                          //
using TS3QueryLib.Core.Server.Responses;                                         //
//-------------------------------------------------------------------------------//

namespace ArgoServerQuery
{
    public class TS3Query
    {
        private const uint CID_NA = 9;        // NA Community-Night Channel-ID
        private const uint CID_EU = 8;        // EU Community-Night Channel-ID
        private const uint CID_AU = 10;       // AU Community-Night Channel-ID
        private const uint CID_SUPPORT = 117; // Support channels Channel-ID (used to define position of move)
        private const uint CID_RTP = 173;     // ReadyToPlay channels Channel-ID 
        private const uint PID = 3;           // Channel parent ID


        public static void moveSvParent(string region)
        {
            // Get the host address, username and port for the ServerQuery Login
            Dictionary<string, string> config = getTSInfo();
            if (config == null) return;

            string sqPW = getSQPassword();
            ushort port;

            Regex regex = new Regex(@"^[0-9]+$");
            if (regex.IsMatch(config["port"]))
            {
                port = Convert.ToUInt16(config["port"]);
            }
            else
            {
                string msg = "ERROR: Invalid port. Port number may contain numbers 1-9 only.";
                string cap = "Error";
                errorMSG(msg, cap);
                return;
            }
            
            // Establish a connection with the TS3 server
            using (QueryRunner QR = new QueryRunner(new SyncTcpDispatcher(config["addr"], port)))
            {
                if (loginAndUse(QR, config, sqPW) != null)
                {
                    uint cid = 0;
                    switch (region)
                    {
                        case "EU":
                            cid = CID_EU;
                            break;
                        case "NA":
                            cid = CID_NA;
                            break;
                        case "AU/NZ":
                            cid = CID_AU;
                            break;
                    }

                    SimpleResponse moveResponse = QR.EditChannel(cid, 
                        new ChannelModification() { ChannelOrder = CID_SUPPORT });

                    if (moveResponse.IsErroneous)
                    {
                        string moveMsg = $"ERROR: {moveResponse.ErrorMessage}\n\n Error ID: {moveResponse.ErrorId}";
                        string moveCap = "Channel Move Failed";
                        errorMSG(moveMsg, moveCap);
                    }
                }
            }
        }

        public static void muteUnmuteRTP(bool state)
        {
            // Get the host address, username and port for the ServerQuery Login
            Dictionary<string, string> config = getTSInfo();
            if (config == null) return;

            string sqPW = getSQPassword();
            ushort port;
            uint talkPwr = (uint)(state ? 50 : 0);

            Regex regex = new Regex(@"^[0-9]+$");
            if (regex.IsMatch(config["port"]))
            {
                port = Convert.ToUInt16(config["port"]);
            }
            else
            {
                string msg = "ERROR: Invalid port. Port number may contain numbers 1-9 only.";
                string cap = "Error";
                errorMSG(msg, cap);
                return;
            }

            // Establish a connection with the TS3 server
            using (QueryRunner QR = new QueryRunner(new SyncTcpDispatcher(config["addr"], port)))
            {
                if (loginAndUse(QR, config, sqPW) != null)
                {
                    SimpleResponse muteResponse = QR.EditChannel(CID_RTP,
                        new ChannelModification() {NeededTalkPower = talkPwr});

                    if (muteResponse.IsErroneous)
                    {
                        string muteMsg = $"ERROR: {muteResponse.ErrorMessage}\n\n Error ID: {muteResponse.ErrorId}";
                        string muteCap = "Mute Channel Failed";
                        errorMSG(muteMsg, muteCap);
                    }
                }
            }
        }

        public static void modalMessage(bool mode)
        {
            // Get the host address, username and port for the ServerQuery Login
            Dictionary<string, string> config = getTSInfo();
            if (config == null) return;

            string sqPW = getSQPassword();
            ushort port;

            Regex regex = new Regex(@"^[0-9]+$");
            if (regex.IsMatch(config["port"]))
            {
                port = Convert.ToUInt16(config["port"]);
            }
            else
            {
                string msg = "ERROR: Invalid port. Port number may contain numbers 1-9 only.";
                string cap = "Error";
                errorMSG(msg, cap);
                return;
            }

            // Establish a connection with the TS3 server
            using (QueryRunner QR = new QueryRunner(new SyncTcpDispatcher(config["addr"], port)))
            {
                if (loginAndUse(QR, config, sqPW) != null)
                {
                    SimpleResponse modalResponse = QR.EditServer(new VirtualServerModification()
                    {
                        HostMessageMode = mode ? HostMessageMode.HostMessageModeModal : HostMessageMode.HostMessageModeNone
                    });

                    if (modalResponse.IsErroneous)
                    {
                        string muteMsg = $"ERROR: {modalResponse.ErrorMessage}\n\n Error ID: {modalResponse.ErrorId}";
                        string muteCap = "Failed to edit Host Message Mode";
                        errorMSG(muteMsg, muteCap);
                    }
                }
            }
        }

        private static QueryRunner loginAndUse(QueryRunner runner, Dictionary<string, string> cfg, string rcon)
        {
            SimpleResponse loginResponse = runner.Login(cfg["user"], rcon);

            if (loginResponse.IsErroneous)
            {
                string loginMsg = $"ERROR: {loginResponse.ErrorMessage}\n\n Error ID:{loginResponse.ErrorId}";
                string loginCap = "Login Failed";
                errorMSG(loginMsg, loginCap);
                return null;
            }

            SimpleResponse useResponse = runner.SelectVirtualServerById(1);

            if (useResponse.IsErroneous)
            {
                string useMsg = $"ERROR: {useResponse.ErrorMessage}\n\n Error ID: {useResponse.ErrorId}";
                string useCap = "SelectVirtualServerById Failed";
                errorMSG(useMsg, useCap);
                return null;
            }

            return runner;
        }

        private static string getSQPassword()
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default.ts3SQPW)
                && !String.IsNullOrEmpty(Properties.Settings.Default.keyTS)
                && !String.IsNullOrEmpty(Properties.Settings.Default.IVTS))
            {
                try
                {
                    using (RijndaelManaged aesDecryptTS = new RijndaelManaged())
                    {
                        aesDecryptTS.Key = Convert.FromBase64String(Properties.Settings.Default.keyTS);
                        aesDecryptTS.IV = Convert.FromBase64String(Properties.Settings.Default.IVTS);
                        byte[] encrypted = Convert.FromBase64String(Properties.Settings.Default.ts3SQPW);

                        return PasswordStorage.DecryptStringFromBytes(encrypted, aesDecryptTS.Key, aesDecryptTS.IV);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                    string message = $"ERROR: Couldn't decrypt ServerQuery password. Make sure you save the config first!\n\nINFO: {ex.Message} \n\nSRC: {ex.Source}";
                    string cap = "Error";
                    errorMSG(message, cap);

                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        private static Dictionary<string, string> getTSInfo()
        {
            Dictionary<string, string> tsConfig = new Dictionary<string, string>();

            if (!String.IsNullOrEmpty(Properties.Settings.Default.ts3Addr)
                && !String.IsNullOrEmpty(Properties.Settings.Default.ts3SQUser)
                && !String.IsNullOrEmpty(Properties.Settings.Default.ts3SQPort))
            {
                tsConfig.Add("addr", Properties.Settings.Default.ts3Addr);
                tsConfig.Add("user", Properties.Settings.Default.ts3SQUser);
                tsConfig.Add("port", Properties.Settings.Default.ts3SQPort);
                return tsConfig;
            }
            else
            {
                string message = "ERROR: Null value found in config! Make sure you completed and saved each field.";
                string cap = "Error";
                errorMSG(message, cap);
                return null;
            }
        }

        private static void errorMSG(string msg, string cap)
        {
            MessageBoxIcon icon = MessageBoxIcon.Error;
            MessageBoxButtons btn = MessageBoxButtons.OK;
            MessageBox.Show(msg, cap, btn, icon);
        }
    }
}
