using SpaceServer.Network.Abstractions;
using SpaceServer.Network.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceServer.Network.Requests
{
    public class SpawnEntityRequest : BaseRequest
    {
        public override byte Id => 0x01;
        public SpawnEntityRequest(SpawnEntity spawnEntity)
        {
            this.body = spawnEntity.ToByteArray();
        }
    }
}
