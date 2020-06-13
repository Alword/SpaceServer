using Xunit;

namespace SpaceServer.Network.Tests.Utils
{
    public class ArrayBuilderTests
    {
        [Fact]
        public void BuildTest()
        {
            byte[] first = new byte[] { 0, 1 };
            byte[] second = new byte[] { 2, 3, 4 };
            byte[] third = new byte[] { 5, 6, 7 };

            var array = ArrayBuilder.Build<byte>(first, second, third);

            Assert.Equal(8, array.Length);

            for (int i = 0; i < 8; i++)
            {
                Assert.Equal(i, array[i]);
            }
        }
    }
}
