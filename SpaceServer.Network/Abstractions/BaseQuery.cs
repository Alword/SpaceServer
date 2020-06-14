using System;

namespace SpaceServer.Network.Abstractions
{
    public abstract class BaseQuery<T> : IQuery
        where T : IPacket
    {
        public abstract byte Id { get; }
        public T Data { get; private set; }
        public BaseQuery(T data)
        {
            Data = data;
        }
        public virtual byte[] Body() => Data.ToByteArray();

        public byte[] ToByteArray()
        {
            var bodyBuf = Body();
            var buf = new byte[bodyBuf.Length + 1];
            buf[0] = Id;
            Array.Copy(bodyBuf, 0, buf, 1, bodyBuf.Length);
            return buf;
        }
    }
}
