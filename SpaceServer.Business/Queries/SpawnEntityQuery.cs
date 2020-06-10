using SpaceServer.Business.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceServer.Business.Queries
{
    public class SpawnEntityQuery : BaseQuery
    {
        public override byte QueryId => 0x01;

        private readonly SpawnEntity spawnEntity;
        public SpawnEntityQuery(SpawnEntity spawnEntity)
        {
            this.spawnEntity = spawnEntity;
        }
        public override byte[] Query()
        {
            return spawnEntity.ToByteArray();
        }
    }
}
