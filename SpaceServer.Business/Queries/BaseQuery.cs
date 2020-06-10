using System;

namespace SpaceServer.Business.Queries
{
    public abstract class BaseQuery : IQuery
    {
        public abstract byte QueryId { get; }

        public abstract byte[] Query();

        public byte[] ToByteArray()
        {
            var query = Query();
            var buf = new byte[query.Length + 1];
            buf[0] = QueryId;
            Array.Copy(query, 0, buf, 1, query.Length);
            return buf;
        }
    }
}
