using SpaceServer.Network.Abstractions;
using SpaceServer.Network.Packets;
using SpaceServer.Network.Types;

namespace SpaceServer.Network.Queries
{
    public class SpawnEntityQuery : BaseQuery, IPacket
    {
        public override byte Id => 0x01;
        public SpawnEntity spawnEntity { get; private set; }
        public uint playerId { get; private set; }
        public uint entityId { get; private set; }
        public SpawnEntityQuery() : this(new SpawnEntity(), 0, 0) { }
        public SpawnEntityQuery(SpawnEntity spawnEntity, uint playerId, uint entityId)
        {
            this.spawnEntity = spawnEntity;
            this.playerId = playerId;
            this.entityId = entityId;
        }
        public override byte[] Body()
        {
            var entityBuf = spawnEntity.ToByteArray();
            var playerIdBuf = Varint.Encode(playerId);
            var entityIdBuf = Varint.Encode(entityId);

            var buf = ArrayBuilder.Build<byte>(entityBuf, playerIdBuf, entityIdBuf);
            return buf;
        }

        public bool TryParse(byte[] buf) => TryRead(ref buf);

        public bool TryRead(ref byte[] buf)
        {
            spawnEntity = new SpawnEntity(ref buf);
            playerId = Varint.ReadUInt(ref buf);
            entityId = Varint.ReadUInt(ref buf);
            return true;
        }
        public override string ToString()
        {
            return $"{spawnEntity.typeId} {spawnEntity.x} {spawnEntity.z} {playerId}";
        }
    }
}
