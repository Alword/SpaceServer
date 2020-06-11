namespace SpaceServer.Network.Abstractions
{
    public interface IQuery
    {
        byte Id { get; }
        byte[] Body();
        byte[] ToByteArray();
    }
}
