namespace SpaceServer.Network.Abstractions
{
    public interface ICommand
    {
        public void Invoke(byte[] body,string connid);
    }
}
