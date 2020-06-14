using SpaceServer.Network.Abstractions;
using SpaceServer.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceServer.Network.Packets
{
    public class MoveEntityServer : BasePacket
    {
        public int[] EntityIds { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public override byte[] ToByteArray()
        {
            List<byte> buf = new List<byte>();
            foreach (var e in EntityIds)
            {
                buf.AddRange(Varint.Encode(e));
            }
            return ArrayBuilder.Build<byte>(
                buf.ToArray(),
                Varint.Encode(X),
                Varint.Encode(Y));
        }

        public override bool TryRead(ref byte[] buf)
        {
            List<int> data = new List<int>();
            while (buf.Length > 0)
            {
                data.Add(Varint.ReadInt(ref buf));
            }
            X = data[data.Count - 1];
            Y = data[data.Count - 2];
            data.RemoveAt(data.Count - 1);
            data.RemoveAt(data.Count - 2);
            EntityIds = data.ToArray();
            return true;
        }
    }
}
