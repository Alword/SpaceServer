namespace SpaceServer.Network.Abstractions
{
    public interface ICommand
    {
        void Invoke(byte[] body,string connid);
    }
}
