using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueryMaster;
using QueryMaster.GameServer;

namespace ArgoServerQuery
{
    class Updates
    {
        public ServerInfo serverInfo { get; set; }
        public string score;

        public Updates(ServerInfo svInfo, string sc)
        {
            this.serverInfo = svInfo;
            this.score = sc;
        }
    }
}
