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
            SpawnEntity spawnEntity = new SpawnEntity();
            spawnEntity.TryParse(body);

            var entity = gameState.Add(new Entity()
            {
                Transform = new Float3(spawnEntity.x, spawnEntity.z),
                TypeId = spawnEntity.typeId
            }, connId);

            // TODO: Add entity id
            var playerid = gameState.ConnPlayerId[connId];
            var query = new SpawnEntityQuery(spawnEntity, playerid, entity.Id);
            gameState.Broadcast(query);
        }
    }
}
