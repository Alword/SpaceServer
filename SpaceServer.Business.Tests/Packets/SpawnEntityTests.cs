using SpaceServer.Network.Packets;
using Xunit;

namespace SpaceServer.Business.Tests.Packets
{
    public class SpawnEntityTests
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(0, -2, -3)]
        [InlineData(int.MaxValue, int.MaxValue, int.MaxValue)]
        [InlineData(int.MinValue, int.MinValue, int.MinValue)]
        public void ConvertSpawnEntity(int eId, int eX, int eZ)
        {
            SpawnEntityServer spawnEntity = new SpawnEntityServer(eId, eX, eZ);
            var bytes = spawnEntity.ToByteArray();

            var recive = new SpawnEntityServer();
            recive.TryRead(ref bytes);

            Assert.Equal(eId, recive.TypeId);
            Assert.Equal(eX, recive.X);
            Assert.Equal(eZ, recive.Z);
        }
    }
}
