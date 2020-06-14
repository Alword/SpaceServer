using SpaceServer.Business.Abstractions;
using SpaceServer.Business.Extentions;
using SpaceServer.Business.Models;
using SpaceServer.Mathematic;
using SpaceServer.Network.Packets;
using SpaceServer.Network.Queries;

namespace SpaceServer.Business.Commands
{
    public class SpawnEntityCommand : BaseCommand<SpawnEntityServer>
    {
        public SpawnEntityCommand(GameState gameState) : base(gameState) { }

        public override void Handle(string connId, SpawnEntityServer data)
        {
            var entity = gameState.Add(new Entity()
            {
                Transform = new Float3(data.X, data.Z),
                TypeId = data.TypeId
            }, connId);

            var playerid = gameState.ConnPlayerId[connId];

            var message = new SpawnEntityClient(entity.TypeId, data.X, data.Z, playerid, entity.Id);
            var query = new SpawnEntityQuery(message);
            
            gameState.Broadcast(query);
        }
    }
}
