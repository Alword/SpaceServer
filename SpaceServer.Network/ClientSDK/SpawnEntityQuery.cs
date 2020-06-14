using SpaceServer.Network.Abstractions;
using SpaceServer.Network.Packets;
using SpaceServer.Network.Types;

namespace SpaceServer.Network.Queries
{
    public class SpawnEntityQuery : BaseQuery<SpawnEntityClient>
    {
        public override byte Id => 0x01;
        public SpawnEntityQuery(SpawnEntityClient spawnEntity) : base(spawnEntity) { }
        public override string ToString()
        {
            return $"{Data.TypeId} {Data.X} {Data.Z} {Data.PlayerId} {Data.EntityId}";
        }
    }
}
