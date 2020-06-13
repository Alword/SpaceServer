using SpaceServer.Business.Models;
using SpaceServer.Mathematic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SpaceServer.Business.Tests.Models
{
    public class PathfinderTests
    {
        [Fact]
        public void FindPath_Ctor()
        {
            Pathfinder pathfinder = new Pathfinder(1, 1);
        }
        [Fact]
        public void FindPathOutOfRange_Nopath()
        {
            // arrange
            Pathfinder pathfinder = new Pathfinder(1, 1);

            // act
            var path = pathfinder.FindPath(new Int2(0, 0), new Int2(2, 2));

            // assert
            Assert.False(path.Any());
        }

        [Fact]
        public void FindPath_NoObstacle()
        {
            // arrange
            Pathfinder pathfinder = new Pathfinder(3, 3);

            // act
            var path = pathfinder.FindPath(new Int2(0, 0), new Int2(2, 2));

            // assert
            Assert.Equal(2, path.Count);
            Assert.Equal(1, path[0].x);
            Assert.Equal(1, path[0].y);
            Assert.Equal(2, path[1].x);
            Assert.Equal(2, path[1].y);
        }
    }
}
