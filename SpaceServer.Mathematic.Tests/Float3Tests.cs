using Xunit;

namespace SpaceServer.Mathematic.Tests
{
    public class Float3Tests
    {
        [Fact]
        public void Multiplication()
        {
            // arrange
            var float3 = new Float3(1, 1, 1);
            // act
            float3 *= 3;
            // assert
            Assert.Equal(3, float3.Z);
            Assert.Equal(3, float3.Y);
            Assert.Equal(3, float3.Z);
        }
    }
}
