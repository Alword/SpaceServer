using SpaceServer.Network.Abstractions;
using System;

namespace SpaceServer.Network.Queries
{
    public abstract class BaseQuery : IQuery
    {
        public abstract byte QueryId { get; }

        public abstract byte[] Body();

        public byte[] ToByteArray()
        {
            var bodyBuf = Body();
            var buf = new byte[bodyBuf.Length + 1];
            buf[0] = QueryId;
            Array.Copy(bodyBuf, 0, buf, 1, bodyBuf.Length);
            return buf;
        }
    }
}
