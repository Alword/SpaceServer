using SpaceServer.Network.Abstractions;
using SpaceServer.Network.Types;
using System.Collections.Generic;

namespace SpaceServer.Network.Packets
{
    public struct SpawnEntity : IPacket
    {
        public uint typeId;
        public int x;
        public int z;

        public SpawnEntity(ref byte[] buf)
        {
            typeId = Varint.ReadUInt(ref buf);
            x = Varint.ReadInt(ref buf);
            z = Varint.ReadInt(ref buf);
        }

        public byte[] ToByteArray()
        {
            List<byte> buf = new List<byte>(sizeof(int) * 3);
            buf.AddRange(Varint.Encode(typeId));
            buf.AddRange(Varint.Encode((uint)x));
            buf.AddRange(Varint.Encode((uint)z));
            return buf.ToArray();
        }

        public bool TryParse(byte[] buf)
        {
            TryRead(ref buf);
            return true;
        }

        public bool TryRead(ref byte[] buf)
        {
            typeId = Varint.ReadUInt(ref buf);
            x = Varint.ReadInt(ref buf);
            z = Varint.ReadInt(ref buf);
            return true;
        }
    }
}
