using SpaceServer.Network.Enums;
using SpaceServer.Network.Packets;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SpaceServer.Network.Tests.Packets
{
    public class MoveEntityClientTests
    {
        [Fact]
        public void Ctor()
        {
            var sendDirections = new MoveDirection[]
            {
                MoveDirection.Up,
                MoveDirection.UpRight,
                MoveDirection.Right,
                MoveDirection.DownRight,
                MoveDirection.Down,
                MoveDirection.DownLeft,
                MoveDirection.Left,
                MoveDirection.UpLeft
            };

            MoveEntityClient moveEntityClient = new MoveEntityClient(1, 2, sendDirections);


            var buf = moveEntityClient.ToByteArray();

            var actual = new MoveEntityClient(ref buf);

            Assert.Empty(buf);
            Assert.Equal(8, actual.Movement.Length);
            Assert.Equal(8, actual.StepCount);
            Assert.Equal<uint>(1, actual.EntityId);
            Assert.Equal<uint>(2, actual.Time);

            for (int i = 0; i < sendDirections.Length; i++)
            {
                Assert.Equal(sendDirections[i], actual.Movement[i]);
            }
        }
    }
}
