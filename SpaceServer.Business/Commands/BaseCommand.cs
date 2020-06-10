using SpaceServer.Business.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceServer.Business.Commands
{
    public abstract class BaseCommand : ICommand
    {
        protected readonly GameState gameState;
        public BaseCommand(GameState gameState)
        {
            this.gameState = gameState;
        }

        public abstract void Invoke(byte[] body);
    }
}
