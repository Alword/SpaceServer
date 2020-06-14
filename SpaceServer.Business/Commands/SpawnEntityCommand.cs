using SpaceServer.Business.Extentions;
using SpaceServer.Business.Models;
using SpaceServer.Mathematic;
using SpaceServer.Network.Packets;
using SpaceServer.Network.Queries;

namespace SpaceServer.Business.Commands
{
    public class SpawnEntityCommand : BaseCommand
    {
        public SpawnEntityCommand(GameState gameState) : base(gameState)
        {
        }

        public override void Invoke(byte[] body, string connId)
        {
            SpawnEntityServer spawnEntity = new SpawnEntityServer();
            spawnEntity.TryParse(body);

            var entity = gameState.Add(new Entity()
            {
                Transform = new Float3(spawnEntity.X, spawnEntity.Z),
                TypeId = spawnEntity.TypeId
            }, connId);

            var playerid = gameState.ConnPlayerId[connId];

            var data = new SpawnEntityClient(entity.TypeId, spawnEntity.X, spawnEntity.Z, playerid, entity.Id);
            var query = new SpawnEntityQuery(data);
            gameState.Broadcast(query);
        }
    }
}
