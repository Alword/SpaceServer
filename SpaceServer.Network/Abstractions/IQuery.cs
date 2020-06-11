namespace SpaceServer.Network.Abstractions
{
    public interface IQuery
    {
        public byte Id { get; }
        public byte[] Body();
        public byte[] ToByteArray();
    }
}
