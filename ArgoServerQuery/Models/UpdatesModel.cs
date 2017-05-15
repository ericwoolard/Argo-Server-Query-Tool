using QueryMaster.GameServer;

namespace ArgoServerQuery.Models
{
    public class UpdatesModel
    {
        private ServerInfo serverInfo { get; }
        private string score { get; }

        public UpdatesModel(ServerInfo svInfo, string sc)
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
