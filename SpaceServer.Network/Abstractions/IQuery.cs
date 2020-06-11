namespace SpaceServer.Network.Abstractions
{
    public interface IQuery
    {
        public byte QueryId { get; }
        public byte[] Body();
        public byte[] ToByteArray();
    }
}
