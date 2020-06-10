using SpaceServer.Business.Models;
using System.Collections.Generic;

namespace SpaceServer.Business.Packets
{
    public struct SpawnEntity : IPacket
    {
        public uint typeId;
        public int x;
        public int y;

        public byte[] ToByteArray()
        {
            List<byte> buf = new List<byte>(sizeof(int) * 3);
            buf.AddRange(Varint.Encode(typeId));
            buf.AddRange(Varint.Encode((uint)x));
            buf.AddRange(Varint.Encode((uint)y));
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
            y = Varint.ReadInt(ref buf);
            return true;
        }
    }
}
