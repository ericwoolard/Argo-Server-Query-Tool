using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using QueryMaster;
using QueryMaster.GameServer;

namespace ArgoServerQuery
{
    class AdminChat : QueryMasterBase
    {

        private const int appId = 730;
        private const int retries = 10;
        private const int timeout = 20000;
        private const UInt16 localPort = 7140;

        //Client uses as receive udp client
        private static UdpClient Client = new UdpClient(localPort);

        private static string svIP;
        private static UInt16 svPort;


        public static void getChats(string ip, RichTextBox box)
        {
            Tuple<string, UInt16> addr = splitAddr(ip);
            string addrIP = addr.Item1;
            svIP = addrIP;
            UInt16 port = addr.Item2;
            svPort = port;
            string rconPW = decryptRcon();

            var server = ServerQuery.GetServerInstance(
                (Game)appId,
                addrIP,
                port,
                throwExceptions: false,
                retries: retries,
                sendTimeout: timeout,
                receiveTimeout: timeout);

            try
            {
                Client.BeginReceive(new AsyncCallback(recv), null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            /*addLogAddr(server, rconPW, txtBox);
            Logs logger = server.GetLogs(localPort);

            using (logger)
            {
                LogEvents playerKill = logger.GetEventsInstance();
                playerKill.PlayerKilled += PlayerKilledEvent;

                logger.Listen(x => Console.WriteLine(x));
                logger.Start();
            }*/
        }

        private static void recv(IAsyncResult res)
        {
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Parse(svIP), svPort);
            byte[] received = Client.EndReceive(res, ref RemoteIpEndPoint);

            //Process codes

            Console.WriteLine(Encoding.UTF8.GetString(received));
            Client.BeginReceive(new AsyncCallback(recv), null);
        }


        private static void PlayerKilledEvent(object sender, KillEventArgs args)
        {
            DateTime time = args.Timestamp;
            LogPlayerInfo player = args.Player;
            LogPlayerInfo victim = args.Victim;
            string team = player.Team;
            string weapon = args.Weapon;
            Console.WriteLine(Convert.ToString(time, CultureInfo.InvariantCulture) + " " + victim + " was killed by " + player + " on " + team + " with " + weapon);
        }

        private static void ChatEventsOnPlayerInjured(object sender, InjureEventArgs injureEventArgs)
        {
            DateTime time = injureEventArgs.Timestamp;
            string chatMsg = injureEventArgs.Damage;
            Console.WriteLine(Convert.ToString(time, CultureInfo.InvariantCulture) + chatMsg);
        }

        private static void ChatEventsOnSay(object sender, ChatEventArgs chatEventArgs)
        {
            DateTime time = chatEventArgs.Timestamp;
            string chatMsg = chatEventArgs.Message;
            Console.WriteLine(Convert.ToString(time, CultureInfo.InvariantCulture) + chatMsg);
        }

        private static Server addLogAddr(Server sv, string pw, RichTextBox txtBox)
        {
            string extIP = new WebClient().DownloadString("http://icanhazip.com");
            extIP = extIP.TrimEnd('\r', '\n');

            string addAddr = "logaddress_add " + extIP + ":" + Convert.ToString(localPort);
            string startTime = DateTime.Now.ToString("HH:mm:ss");

            if (sv.GetControl(pw))
            {
                string response = sv.Rcon.SendCommand(addAddr);
                string txtOutput = $"\n...\n...\n...\n...\n...\n...\n...\n...\n{startTime}: {addAddr.ToUpper()}\n{response}\n\n";
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
