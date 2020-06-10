using Serilog;
using SpaceServer.Business.Abstractions;
using SpaceServer.Business.Properties;
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

        public static ICommand Empty => new EmptyCommand();
        public abstract void Invoke(byte[] body);
    }

    public class EmptyCommand : ICommand
    {
        public void Invoke(byte[] body)
        {
            Log.Error(Text.CommandNotFound);
        }
    }
}
