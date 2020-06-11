using SpaceServer.Network.Packets;
using SpaceServer.Network.Types;
using System;

namespace SpaceServer.Network.Queries
{
    public class SpawnEntityQuery : BaseQuery
    {
        public override byte Id => 0x01;

        private readonly SpawnEntity spawnEntity;
        private readonly uint playerId;
        public SpawnEntityQuery(SpawnEntity spawnEntity, uint playerId)
        {
            this.spawnEntity = spawnEntity;
        }
        public override byte[] Body()
        {
            var entityBuf = spawnEntity.ToByteArray();
            var idBuf = Varint.Encode(playerId);
            var buf = new byte[entityBuf.Length + idBuf.Length];
            Array.Copy(entityBuf, 0, buf, 0, entityBuf.Length);
            Array.Copy(idBuf, 0, buf, entityBuf.Length, idBuf.Length);
            return buf;
        }
    }
}
