using Serilog;
using SpaceServer.Business.Properties;
using SpaceServer.Network.Abstractions;

namespace SpaceServer.Business.Commands
{
    public abstract class BaseCommand : ICommand
    {
        protected readonly GameState gameState;
        public BaseCommand(GameState gameState)
        {
            this.gameState = gameState;
        }

        public static ICommand Empty => new EmptyCommand();
        public abstract void Invoke(byte[] body, string connId);
    }

    public class EmptyCommand : ICommand
    {
        public void Invoke(byte[] body, string connId)
        {
            Log.Error(Text.CommandNotFound);
        }
    }
}
