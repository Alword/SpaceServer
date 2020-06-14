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
            // TODO move all
            // but now - move first

            int entityId = data.EntityIds.First();
            Int2 end = new Int2(data.X, data.Y);

            var entity = gameState.Entities[entityId];
            Int2 start = new Int2(entity.Transform.X, entity.Transform.Z);

            var path = gameState.Terrain.FindPath(start, end);
        }
    }
}
