using SpaceServer.Business.Models;
using SpaceServer.Business.Packets;
using SpaceServer.Mathematic;

namespace SpaceServer.Business.Commands
{
    public class SpawnEntityCommand : BaseCommand
    {
        public SpawnEntityCommand(GameState gameState) : base(gameState)
        {
        }

        public override void Invoke(byte[] body)
        {
            SpawnEntity spawnEntity = new SpawnEntity();
            spawnEntity.TryParse(body);

            gameState.Add(new Entity()
            {
                Transform = new Float3(spawnEntity.x, spawnEntity.y),
                TypeId = spawnEntity.typeId
            });
        }
    }
}
