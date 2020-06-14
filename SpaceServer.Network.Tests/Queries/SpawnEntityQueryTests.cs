using SpaceServer.Network.Packets;
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
            var byteArray = new byte[] { 0, 12, 4, 0, 0 };

            var data = new SpawnEntityClient();
            data.TryRead(ref byteArray);
            // act
            SpawnEntityQuery spawnEntityQuery = new SpawnEntityQuery(data);

            // assert
            Assert.Equal<uint>(0, spawnEntityQuery.Data.TypeId);
            Assert.Equal(12, spawnEntityQuery.Data.X);
            Assert.Equal(4, spawnEntityQuery.Data.Z);
            Assert.Equal<uint>(0, spawnEntityQuery.Data.PlayerId);
            Assert.Equal<uint>(0, spawnEntityQuery.Data.EntityId);
        }
    }
}
