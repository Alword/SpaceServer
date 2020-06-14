﻿using SpaceServer.Network.Abstractions;
using SpaceServer.Network.Types;

namespace SpaceServer.Network.Packets
{
    public class SpawnEntityServer : BasePacket
    {
        public uint TypeId { get; private set; }
        public int X { get; private set; }
        public int Z { get; private set; }
        public SpawnEntityServer() { }

        public SpawnEntityServer(uint typeId, int x, int z)
        {
            TypeId = typeId;
            X = x;
            Z = z;
        }

        public override byte[] ToByteArray()
        {
            return ArrayBuilder.Build<byte>(
                Varint.Encode(TypeId),
                Varint.Encode((uint)X),
                Varint.Encode((uint)Z)
                );
        }

        public override bool TryRead(ref byte[] buf)
        {
            TypeId = Varint.ReadUInt(ref buf);
            X = Varint.ReadInt(ref buf);
            Z = Varint.ReadInt(ref buf);
            return true;
        }
    }
}
