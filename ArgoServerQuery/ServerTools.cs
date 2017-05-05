using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArgoServerQuery
{
    public class ServerTools
    {
        const string pES_APIKEY = "";
        const string API_URL = "https://api.pes.gs/v1/servers";

        public static void serverList(string address)
        {
            var webRequest = System.Net.WebRequest.Create(API_URL);
            if (webRequest != null)
            {
                webRequest.Method = "GET";
                webRequest.Timeout = 12000;
                webRequest.ContentType = "application/json";
                webRequest.Headers.Add("Authorization", pES_APIKEY);

                using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                    {
                        string jsonResponse = sr.ReadToEnd();
                        Console.WriteLine(jsonResponse);
                    }
                }
            }
        }

        public static string copySteamID(string name, string addr)
        {
            const string cmd = "status";
            string pattern = $"(.{name}.)(.STEAM_)([0-1]:[0-1]:[0-9]+)";
            string matchErr = $"Could not find a regex match for the SteamID of \"{name}\" on the server.";

            string rconResp = Query.sendStatus(addr, cmd);

            if (String.IsNullOrEmpty(rconResp))
            {
                return null;
            }

            var match = Regex.Match(rconResp, pattern);
            var matchVal = match.Groups[0].Value;

            return !String.IsNullOrEmpty(matchVal) ? (match.Groups[2].Value + match.Groups[3].Value).Trim() : matchErr;
        }

        public static string copyPlayerIP(string name, string addr)
        {
            string cmd = $"getplayerip {name}";

            string response = Query.sendRcon(addr, cmd);
            if (String.IsNullOrEmpty(response))
            {
                return null;
            }
            if (response == "[SM] No matching client was found.")
            {
                return null;
            }

            string[] split = response.Split(':');
            string ip = split[1].Trim();
            return ip;
        }
    }
}
