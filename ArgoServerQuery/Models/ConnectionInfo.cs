using System.Net;

namespace ArgoServerQuery.Models
{
    public class ConnectionInfo
    {
        public IPEndPoint EndPoint { get; set; }

        public int SendTimeout { get; set; }

        public int ReceiveTimeout { get; set; }

        public int Retries { get; set; }

        public bool ThrowExceptions { get; set; }
    }
}
