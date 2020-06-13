using SpaceServer.Network.Queries;
using Xunit;

namespace SpaceServer.Network.Tests.Queries
{
    public class SpawnEntityQueryTests
    {
        [Fact]
        public void TryReadTest()
        {
            // arrange
            var byteArray = new byte[] { 0, 12, 4, 0 };

            // act
            SpawnEntityQuery spawnEntityQuery = new SpawnEntityQuery();
            spawnEntityQuery.TryRead(ref byteArray);

            // assert
            Assert.Equal<uint>(0, spawnEntityQuery.spawnEntity.typeId);
            Assert.Equal(12, spawnEntityQuery.spawnEntity.x);
            Assert.Equal(4, spawnEntityQuery.spawnEntity.z);
            Assert.Equal<uint>(0, spawnEntityQuery.playerId);
        }
    }
}
