using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueryMaster;
using QueryMaster.GameServer;

namespace ArgoServerQuery
{
    public class Updates
    {
        private ServerInfo serverInfo { get; set; }
        private string score;

        public Updates(ServerInfo svInfo, string sc)
        {
            this.serverInfo = svInfo;
            this.score = sc;
        }

        public ServerInfo getServerInfo()
        {
            return this.serverInfo;
        }

        public string getScore()
        {
            return this.score;
        }
    }
}
