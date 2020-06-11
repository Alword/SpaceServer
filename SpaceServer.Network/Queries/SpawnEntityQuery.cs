using SpaceServer.Network.Abstractions;
using SpaceServer.Network.Packets;
using SpaceServer.Network.Types;
using System;

namespace SpaceServer.Network.Queries
{
    public class SpawnEntityQuery : BaseQuery, IPacket
    {
        public override byte Id => 0x01;
        public SpawnEntity spawnEntity { get; private set; }
        public uint playerId { get; private set; }
        public SpawnEntityQuery() : this(new SpawnEntity(), 0) { }
        public SpawnEntityQuery(SpawnEntity spawnEntity, uint playerId)
        {
            this.spawnEntity = spawnEntity;
            this.playerId = playerId;
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

        public bool TryParse(byte[] buf) => TryRead(ref buf);

        public bool TryRead(ref byte[] buf)
        {
            var readEntity = new SpawnEntity();
            readEntity.TryRead(ref buf);
            spawnEntity = readEntity;
            playerId = Varint.ReadUInt(ref buf);
            return true;
        }
    }
}
