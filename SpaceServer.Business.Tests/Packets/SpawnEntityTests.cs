using SpaceServer.Network.Packets;
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
                z = eY
            };
            var bytes = spawnEntity.ToByteArray();

            var recive = new SpawnEntity();
            recive.TryRead(ref bytes);

            Assert.Equal(eId, recive.typeId);
            Assert.Equal(eX, recive.x);
            Assert.Equal(eY, recive.z);
        }
    }
}
