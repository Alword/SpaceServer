using SpaceServer.Business.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceServer.Business.Commands
{
    public class MoveEntityCommand : BaseCommand
    {
        public MoveEntityCommand(GameState gameState) : base(gameState)
        {
        }

        public override void Invoke(byte[] body, string connId)
        {
            throw new NotImplementedException();
        }
    }
}
