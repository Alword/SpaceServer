using SpaceServer.Network.Abstractions;
using SpaceServer.Network.Extentions;
using SpaceServer.Network.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceServer.Network
{
    public class QueryHandler
    {
        public delegate void QueryEvent(byte queryId, byte[] message);
        private readonly Dictionary<byte, List<QueryEvent>> querySubs;

        private readonly HashSet<byte> ProtocolQuery;
        public QueryHandler()
        {
            querySubs = new Dictionary<byte, List<QueryEvent>>();

            ProtocolQuery = new HashSet<byte>()
            {
                0x01 // SpawnEntityQuery
            };
        }

        public void Subscribe(byte id, QueryEvent handler)
        {
            if (querySubs.ContainsKey(id))
            {
                querySubs[id].Add(handler);
            }
            else
            {
                querySubs.Add(id, new List<QueryEvent> { handler });
            }
        }

        public void Recieve(byte[] query)
        {
            byte id = query[0];
            if (querySubs.ContainsKey(id))
            {
                var message = query.ToArray(1);
                foreach (var d in querySubs[id])
                {
                    d.Invoke(id, message);
                }
            }
        }
    }
}
