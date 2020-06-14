using SpaceServer.Network.Abstractions;
using SpaceServer.Network.Packets;

namespace SpaceServer.Network.ServerSDK
{
    public class MoveEntityRequest : BaseQuery<MoveEntityServer>
    {
        public override byte Id => 0x01;
        public MoveEntityRequest(MoveEntityServer moveEntityPacket) : base(moveEntityPacket) { }
    }
}
