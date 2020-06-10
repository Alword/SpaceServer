using SpaceServer.Business.Models;
using SpaceServer.Business.Packets;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SpaceServer.Business.Tests.Packets
{
    public class SpawnEntityTests
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(-1, -2, -3)]
        [InlineData(int.MaxValue, int.MaxValue, int.MaxValue)]
        [InlineData(int.MinValue, int.MinValue, int.MinValue)]
        public void ConvertSpawnEntity(int eId, int eX, int eY)
        {
            SpawnEntity spawnEntity = new SpawnEntity()
            {
                id = eId,
                x = eX,
                y = eY
            };
            var bytes = spawnEntity.ToByteArray();
            (ulong id, int n1) = Varint.Decode(bytes);
            (ulong x, int n2) = Varint.Decode(bytes[n1..]);
            (ulong y, int n3) = Varint.Decode(bytes[(n1 + n2)..]);
            Assert.Equal(eId, (int)id);
            Assert.Equal(eX, (int)x);
            Assert.Equal(eY, (int)y);
        }
    }
}
