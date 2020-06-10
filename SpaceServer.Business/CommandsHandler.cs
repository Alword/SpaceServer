using SpaceServer.Business.Abstractions;
using SpaceServer.Business.Commands;
using SpaceServer.Business.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceServer.Business
{
    public class CommandsHandler
    {
        private readonly Dictionary<byte, ICommand> commands;

        public CommandsHandler(GameState gameState)
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
