using SpaceServer.Network.Abstractions;
using SpaceServer.Network.Packets;

namespace SpaceServer.Network.ServerSDK
{
    public class SpawnEntityRequest : BaseQuery<SpawnEntityServer>
    {
        public override byte Id => 0x01;
        public SpawnEntityRequest(SpawnEntityServer spawnEntity) : base(spawnEntity) { }
    }
}
