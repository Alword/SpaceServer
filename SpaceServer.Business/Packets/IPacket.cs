namespace SpaceServer.Business.Packets
{
    public interface IPacket
    {
        public byte[] ToByteArray();
        public bool TryParse(byte[] buf);
        public bool TryRead(ref byte[] buf);
    }
}
