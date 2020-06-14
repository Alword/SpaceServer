using SpaceServer.Business.Models;
using SpaceServer.Mathematic;
using System.Collections.Generic;
using System.Linq;
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


        //
        //[ ] [ ] [1]
        //[ ] [0] [ ]
        //[S] [ ] [ ]
        [Fact]
        public void FindPath_NoObstacle()
        {
            // arrange
            Pathfinder pathfinder = new Pathfinder(3, 3);

            // act
            List<Int2> path = pathfinder.FindPath(new Int2(0, 0), new Int2(2, 2));

            // assert
            Assert.Equal(2, path.Count);
            Assert.Equal(new Int2(1, 1), path[0]);
            Assert.Equal(new Int2(2, 2), path[1]);
        }

        //
        //[ ] [ ] [2]
        //[ ] [X] [1]
        //[S] [0] [ ]
        [Fact]
        public void FindPath_Obstacle()
        {
            // arrange
            Pathfinder pathfinder = new Pathfinder(3, 3);
            pathfinder.AddObstacle(new Int2(1, 1));
            // act
            List<Int2> path = pathfinder.FindPath(new Int2(0, 0), new Int2(2, 2));

            // assert
            Assert.Equal(3, path.Count);
        }
    }
}
