using SpaceServer.Network.Packets;

namespace SpaceServer.Network.Requests
{
    public class SpawnEntityRequest : BaseRequest
    {
        public override byte Id => 0x01;
        public SpawnEntityRequest(SpawnEntity spawnEntity)
        {
            this.body = spawnEntity.ToByteArray();
        }
    }
}
