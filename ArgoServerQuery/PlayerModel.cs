using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ArgoServerQuery
{
    [JsonObject(MemberSerialization.OptIn)]
    public class PlayerModel
    {
        [JsonProperty]
        private string name { get; set; }

        [JsonProperty]
        private string team { get; set; }

        [JsonProperty]
        private string frags { get; set; }

        [JsonProperty]
        private string deaths { get; set; }

        public PlayerModel(string pName, string pTeam, string pFrags, string pDeaths)
        {
            this.name = pName;
            this.team = pTeam;
            this.frags = pFrags;
            this.deaths = pDeaths;
        }

        public string getName() { return this.name; }
        public string getTeam() { return this.team; }
        public string getFrags() { return this.frags; }
        public string getDeaths() { return this.deaths; }
    }
}
