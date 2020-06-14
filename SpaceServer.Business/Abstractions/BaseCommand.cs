using Serilog;
using SpaceServer.Business.Properties;
using SpaceServer.Network.Abstractions;

namespace SpaceServer.Business.Abstractions
{
    public abstract class BaseCommand<T> : ICommand
        where T : BasePacket, new()
    {
        protected readonly GameState gameState;
        public BaseCommand(GameState gameState)
        {
            this.gameState = gameState;
        }
        public static ICommand Empty => new EmptyCommand();
        public virtual void Invoke(byte[] body, string connId)
        {
            var data = new T();
            data.TryRead(ref body);
            Handle(connId, data);
        }
        public abstract void Handle(string connId, T data);
    }

    public class EmptyCommand : ICommand
    {
        public void Invoke(byte[] body, string connId)
        {
            Log.Error(Text.CommandNotFound);
        }
    }
}
