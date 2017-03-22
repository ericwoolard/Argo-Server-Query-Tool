using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QueryMaster;
using QueryMaster.GameServer;

namespace ArgoServerQuery
{
    class AdminChat : QueryMasterBase
    {

        private const int appId = 730;
        private const int retries = 0;
        private const int timeout = 2000;


        public static void getChats(string ip, RichTextBox txtBox)
        {
            Tuple<string, UInt16> addr = splitAddr(ip);
            string addrIP = addr.Item1;
            UInt16 port = addr.Item2;
            string rconPW = decryptRcon();

            var server = ServerQuery.GetServerInstance(
                (Game)appId,
                addrIP,
                port,
                throwExceptions: false,
                retries: retries);

            addLogAddr(ref server, rconPW, txtBox);

            using (Logs logger = server.GetLogs(port))
            {
                LogEvents chatEvents = logger.GetEventsInstance();
                //chatEvents.
            }

        }

        private static Server addLogAddr(ref Server sv, string pw, RichTextBox txtBox)
        {
            string extIp = new WebClient().DownloadString("http://icanhazip.com");
            string addAddr = $"logaddress_add {extIp}";
            string startTime = DateTime.Now.ToString("HH:mm:ss");

            if (sv.GetControl(pw))
            {
                string response = sv.Rcon.SendCommand(addAddr);
                string txtOutput = $"\n...\n...\n...\n...\n...\n...\n...\n...{startTime}: {addAddr.ToUpper()}\n{response}\n\n";
                txtBox.AppendText(txtOutput);
                return sv;
            }

            return null;
        }

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
