using SpaceServer.Network.Abstractions;
using SpaceServer.Network.Packets;
using System;

namespace SpaceServer.Network.ClientSDK
{
    public class MoveEntityQuery : BaseQuery<MoveEntityClient>
    {
        public override byte Id => 0x01;
        public MoveEntityQuery(MoveEntityClient data) : base(data) { }
    }
}
