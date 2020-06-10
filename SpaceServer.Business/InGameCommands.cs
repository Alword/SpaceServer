using SpaceServer.Business.Abstractions;
using SpaceServer.Business.Commands;
using System.Collections.Generic;

namespace SpaceServer.Business
{
    public class InGameCommands
    {
        private readonly Dictionary<byte, ICommand> commands;

        public InGameCommands(GameState gameState)
        {
            commands = new Dictionary<byte, ICommand>
            {
                {0x1,new SpawnEntityCommand(gameState)}
            };
        }

        public ICommand this[byte id]
        {
            get
            {
                if (commands.ContainsKey(id))
                {
                    return commands[id];
                }
                return BaseCommand.Empty;
            }
        }
    }
}
