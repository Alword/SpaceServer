namespace SpaceServer.Business.Abstractions
{
    public interface ICommand
    {
        public void Invoke(byte[] body);
    }
}
