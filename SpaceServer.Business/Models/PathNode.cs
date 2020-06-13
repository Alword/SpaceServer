using SpaceServer.Mathematic;
using SpaceServer.Network.Models;
using System;
using System.Collections.Generic;

namespace SpaceServer.Business.Models
{
    public class PathNode
    {
        private NavGrid<PathNode> grid;
        public readonly int x;
        public readonly int y;
        public Int2 Pos { get => new Int2(x, y); }

        public int gCost;
        public int hCost;
        public int fCost;
        public bool IsEmpty;

        public PathNode CameFromNode;
        public List<PathNode> NeighbourList;
        public PathNode(NavGrid<PathNode> grid, int x, int y)
        {
            this.grid = grid;
            this.x = x;
            this.y = y;
            this.IsEmpty = true;
        }

        public override string ToString()
        {
            return $"{x},{y}";
        }

        public void CalculateFCost()
        {
            fCost = gCost + hCost;
        }

        public PathNode[] GetRectangle(Int2 secondNode)
        {
            Int2 firstNode = new Int2(x, y);

            int capacity = (Math.Abs(firstNode.X - secondNode.X) + 1) * (Math.Abs(firstNode.Y - secondNode.Y) + 1);

            int minX = Math.Min(firstNode.X, secondNode.X);
            int maxX = Math.Max(firstNode.X, secondNode.X);
            int minY = Math.Min(firstNode.Y, secondNode.Y);
            int maxY = Math.Max(firstNode.Y, secondNode.Y);

            var pathNodes = new PathNode[capacity];

            int i = 0;
            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    pathNodes[i++] = grid[x, y];
                }
            }

            return pathNodes;
        }
    }
}
