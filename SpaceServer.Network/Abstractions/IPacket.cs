namespace SpaceServer.Network.Abstractions
{
    public interface IPacket
    {
        public byte[] ToByteArray();
        public bool TryParse(byte[] buf);
        public bool TryRead(ref byte[] buf);
    }
}
