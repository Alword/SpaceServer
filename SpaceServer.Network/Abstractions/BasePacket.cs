namespace SpaceServer.Network.Abstractions
{
    public abstract class BasePacket : IPacket
    {
        public BasePacket()
        {

        }

        public BasePacket(ref byte[] buf)
        {
            TryRead(ref buf);
        }

        public BasePacket(byte[] buf)
        {
            TryRead(ref buf);
        }

        public abstract byte[] ToByteArray();

        public virtual bool TryParse(byte[] buf) => TryRead(ref buf);

        public abstract bool TryRead(ref byte[] buf);
    }
}
