using SpaceServer.Network.Abstractions;
using SpaceServer.Network.Types;

namespace SpaceServer.Network.Packets
{
    public class SpawnEntityClient : BasePacket
    {
        public int TypeId { get; private set; }
        public int X { get; private set; }
        public int Z { get; private set; }
        public int PlayerId { get; private set; }
        public int EntityId { get; private set; }

        public SpawnEntityClient() { }
        public SpawnEntityClient(int typeId, int x, int z, int playerId, int entityId)
        {
            this.TypeId = TypeId;
            this.X = x;
            this.Z = z;
            this.PlayerId = playerId;
            this.EntityId = entityId;
        }

        public override byte[] ToByteArray()
        {
            return ArrayBuilder.Build<byte>(
                Varint.Encode(TypeId),
                Varint.Encode(X),
                Varint.Encode(Z),
                Varint.Encode(PlayerId),
                Varint.Encode(EntityId)
                );
        }

        public override bool TryRead(ref byte[] buf)
        {
            TypeId = Varint.ReadInt(ref buf);
            X = Varint.ReadInt(ref buf);
            Z = Varint.ReadInt(ref buf);
            PlayerId = Varint.ReadInt(ref buf);
            EntityId = Varint.ReadInt(ref buf);
            return true;
        }
    }
}
