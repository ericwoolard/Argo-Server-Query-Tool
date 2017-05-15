using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ArgoServerQuery.Models;
using QueryMaster;
using QueryMaster.GameServer;

namespace ArgoServerQuery
{
    public class Rules
    {
        internal UdpQuery UdpSocket;
        private ConnectionInfo connInfo { get; set; }
        private Server server { get; set; }
        private byte[] RuleChallengeId;
        private bool IsRuleChallengeId;

        internal static readonly byte[] RuleQuery = new byte[5]
        {
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            (byte) 86
        };

        internal static readonly byte[] RuleChallengeQuery = new byte[9]
        {
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            (byte) 86,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue
        };

        internal static readonly byte[] ObsoleteRuleQuery = new byte[9]
        {
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            (byte) 114,
            (byte) 117,
            (byte) 108,
            (byte) 101,
            (byte) 115
        };

        internal enum ResponseMsgHeader : byte
        {
            A2S_SERVERQUERY_GETCHALLENGE = 65,
            A2S_PLAYER = 68,
            A2S_RULES = 69,
            A2S_INFO = 73,
            A2S_INFO_Obsolete = 109,
        }

        public Rules(Server sv)
        {
            this.server = sv;
            //this.UdpSocket.Socket.SendTimeout = server.SendTimeout;
            //this.UdpSocket.Socket.ReceiveTimeout = server.ReceiveTimeout;
        }

        public List<RulesModel> getRules()
        {
            this.connInfo = new ConnectionInfo()
            {
                EndPoint = server.EndPoint,
                ReceiveTimeout = server.ReceiveTimeout,
                Retries = 1,
                SendTimeout = server.SendTimeout,
                ThrowExceptions = false
            };
            this.UdpSocket = new UdpQuery(connInfo);

            byte[] data = null;
            List<RulesModel> ruleList;
            try
            {
                if (server.IsObsolete)
                {
                    //data = UdpSocket.getResponse(ObsoleteRuleQuery, QueryMaster.EngineType.Source, false);
                }
                else
                {
                    if (RuleChallengeId == null)
                    {
                        data = getRuleChallengeId();

                        if (IsRuleChallengeId)
                        {
                            RuleChallengeId = data;
                        }
                    }
                    if (IsRuleChallengeId)
                    {
                        //data = UdpSocket.getResponse(mergeByteArrays(RuleQuery, RuleChallengeId), QueryMaster.EngineType.Source, true);
                    }
                }

                Parser parser = new Parser(data);

                if (parser.ReadByte() != 69)
                {
                    throw new InvalidHeaderException("A2S_RULES message header is not valid");
                }
                int capacity = parser.ReadUShort();
                ruleList = new List<RulesModel>(capacity);

                for (int index = 0; index < capacity; ++index)
                {
                    ruleList.Add(new RulesModel { Name = parser.ReadString(), Value = parser.ReadString() });
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("ReceivedData", data ?? new byte[1]);
                throw;
            }
            return ruleList;
        }

        private byte[] getRuleChallengeId()
        {
            var recvBytes = UdpSocket.getResponse(RuleChallengeQuery, EngineType.Source);
            try
            {
                var parser = new Parser(recvBytes);
                var header = parser.ReadByte();

                switch (header)
                {
                    case (byte)ResponseMsgHeader.A2S_SERVERQUERY_GETCHALLENGE:
                        IsRuleChallengeId = true;
                        return BitConverter.GetBytes(parser.ReadInt());
                    case (byte)ResponseMsgHeader.A2S_RULES:
                        IsRuleChallengeId = false;
                        return recvBytes;
                    default:
                        throw new InvalidHeaderException("A2S_SERVERQUERY_GETCHALLENGE message header is not valid");
                }
            }
            catch (Exception e)
            {
                e.Data.Add("ReceivedData", recvBytes);
                throw;
            }
        }

        internal static byte[] mergeByteArrays(byte[] array1, byte[] array2)
        {
            byte[] numArray = new byte[array1.Length + array2.Length];
            Buffer.BlockCopy((Array)array1, 0, (Array)numArray, 0, array1.Length);
            Buffer.BlockCopy((Array)array2, 0, (Array)numArray, array1.Length, array2.Length);
            return numArray;
        }



        /// <summary>
        ///   Retrieves  server rules
        /// </summary>
        /// <returns>ReadOnlyCollection of Rule instances</returns>
        public ReadOnlyCollection<RulesModel> GetRules(Action<int> failedAttemptCallback = null)
        {
            //return RunWithRetries(GetRulesCore, connInfo.Retries, failedAttemptCallback);
            return GetRulesCore();
        }

        protected virtual ReadOnlyCollection<RulesModel> GetRulesCore()
        {
            byte[] recvData = null;
            if (server.IsObsolete)
            {
                recvData = UdpSocket.getResponse(ObsoleteRuleQuery, EngineType.Source);
            }
            else
            {
                if (RuleChallengeId == null)
                {
                    recvData = getRuleChallengeId();
                    if (IsRuleChallengeId)
                    {
                        RuleChallengeId = recvData;
                    }
                }
                if (IsRuleChallengeId)
                {
                    recvData = UdpSocket.getResponse(mergeByteArrays(RuleQuery, RuleChallengeId), EngineType.Source);
                }
            }
            try
            {
                var parser = new Parser(recvData);
                if (parser.ReadByte() != (byte) ResponseMsgHeader.A2S_RULES)
                {
                    throw new InvalidHeaderException("A2S_RULES message header is not valid");
                }

                int count = parser.ReadUShort(); //number of rules
                var rules = new List<RulesModel>(count);
                for (var i = 0; i < count; i++)
                {
                    rules.Add(new RulesModel { Name = parser.ReadString(), Value = parser.ReadString() });
                }
                return rules.AsReadOnly();
            }
            catch (Exception e)
            {
                e.Data.Add("ReceivedData", recvData);
                throw;
            }
        }

        internal static T RunWithRetries<T>(Func<T> action, int maxTries, Action<int> onTimeout = null)
        {
            int attempt = 0;
            while (true)
            {
                ++attempt;
                try
                {
                    return action();
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode != SocketError.TimedOut)
                        throw;

                    if (onTimeout != null)
                        onTimeout(attempt);

                    if (attempt >= maxTries)
                        return default(T);
                }
            }
        }
    }
}
