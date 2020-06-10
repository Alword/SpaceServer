using SpaceServer.Business.Models;
using SpaceServer.Business.Packets;
using Xunit;

namespace SpaceServer.Business.Tests.Packets
{
    public class SpawnEntityTests
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(0, -2, -3)]
        [InlineData(uint.MaxValue, int.MaxValue, int.MaxValue)]
        [InlineData(uint.MinValue, int.MinValue, int.MinValue)]
        public void ConvertSpawnEntity(uint eId, int eX, int eY)
        {
            SpawnEntity spawnEntity = new SpawnEntity()
            {
                typeId = eId,
                x = eX,
                y = eY
            };
            var bytes = spawnEntity.ToByteArray();
            uint id = Varint.ReadUInt(ref bytes);
            int x = Varint.ReadInt(ref bytes);
            int y = Varint.ReadInt(ref bytes);
            Assert.Equal(eId, id);
            Assert.Equal(eX, x);
            Assert.Equal(eY, y);
        }
    }
}
