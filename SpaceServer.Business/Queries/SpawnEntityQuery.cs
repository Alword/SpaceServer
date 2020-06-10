using SpaceServer.Business.Packets;

namespace SpaceServer.Business.Queries
{
    public class SpawnEntityQuery : BaseQuery
    {
        public override byte QueryId => 0x01;

        private readonly SpawnEntity spawnEntity;
        public SpawnEntityQuery(SpawnEntity spawnEntity)
        {
            this.spawnEntity = spawnEntity;
        }
        public override byte[] Query()
        {
            return spawnEntity.ToByteArray();
        }
    }
}
