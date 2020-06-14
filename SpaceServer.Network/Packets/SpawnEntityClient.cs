using SpaceServer.Network.Abstractions;
using SpaceServer.Network.Types;

namespace SpaceServer.Network.Packets
{
    public class SpawnEntityClient : BasePacket
    {
        public uint TypeId { get; private set; }
        public int X { get; private set; }
        public int Z { get; private set; }
        public uint PlayerId { get; private set; }
        public uint EntityId { get; private set; }

        public SpawnEntityClient() { }
        public SpawnEntityClient(uint typeId, int x, int z, uint playerId, uint entityId)
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
                Varint.Encode((uint)X),
                Varint.Encode((uint)Z),
                Varint.Encode((uint)PlayerId),
                Varint.Encode((uint)EntityId)
                );
        }

        public override bool TryRead(ref byte[] buf)
        {
            TypeId = Varint.ReadUInt(ref buf);
            X = Varint.ReadInt(ref buf);
            Z = Varint.ReadInt(ref buf);
            PlayerId = Varint.ReadUInt(ref buf);
            EntityId = Varint.ReadUInt(ref buf);
            return true;
        }
    }
}
