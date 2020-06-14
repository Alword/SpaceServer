using SpaceServer.Business.Abstractions;
using SpaceServer.Mathematic;
using SpaceServer.Network.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceServer.Business.Commands
{
    public class MoveEntityCommand : BaseCommand<MoveEntityServer>
    {
        public MoveEntityCommand(GameState gameState) : base(gameState) { }

        public override void Handle(string connId, MoveEntityServer data)
        {
            //Int2 start = gameState.Entities
            //gameState.Terrain.FindPath()
        }
    }
}
