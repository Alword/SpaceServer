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
        private readonly Dictionary<int, ICommand> commands;

        public CommandsHandler(GameState gameState)
        {
            commands = new Dictionary<int, ICommand>
            {
                {0x1,new SpawnEntityCommand(gameState)}
            };
        }
    }
}
