using SpaceServer.Mathematic;
using SpaceServer.Network.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceServer.Business.Models
{
    public partial class Pathfinder
    {
        private const int STRAIGHT_COST = 10;
        private const int DIAGONAL_COST = 14;

        private readonly NavGrid<PathNode> buildings;
        private List<PathNode> openList;
        private HashSet<PathNode> closedList;

        public Pathfinder(int width, int height, float cellSize = 1f)
        {
            this.buildings = new NavGrid<PathNode>(
                width,
                height,
                cellSize,
                (NavGrid<PathNode> g, int x, int y) => new PathNode(g, x, y));

            Parallel.For(0, buildings.Width, (x) =>
            {
                for (int y = 0; y < buildings.Height; y++)
                {
                    PathNode pathNode = buildings[x, y];
                    pathNode.NeighbourList = GetNeighbours(pathNode);
                }
            });
        }

        public List<Int2> FindPath(Int2 start, Int2 end)
        {
            if (!InRange(start) || !InRange(end)) return new List<Int2>() { };

            PathNode startNode = buildings[start];
            PathNode endNode = buildings[end];

            openList = new List<PathNode>() { startNode };

            closedList = new HashSet<PathNode>();

            Parallel.For(0, buildings.Width, (x) =>
            {
                for (int y = 0; y < buildings.Height; y++)
                {
                    PathNode pathNode = buildings[x, y];
                    pathNode.gCost = int.MaxValue;
                    pathNode.CalculateFCost();
                    pathNode.CameFromNode = null;
                }
            });

            startNode.gCost = 0;
            startNode.hCost = CalculateDistance(startNode, endNode);
            startNode.CalculateFCost();

            while (openList.Count > 0)
            {
                PathNode currentNode = GetLowestFCostNode(openList);
                if (currentNode == endNode)
                {
                    // Finel node
                    return CalculatePath(currentNode);
                }

                openList.Remove(currentNode);
                closedList.Add(currentNode);

                foreach (PathNode neighbourNode in currentNode.NeighbourList)
                {
                    if (closedList.Contains(neighbourNode) || neighbourNode == null) continue;
                    if (!neighbourNode.IsEmpty)
                    {
                        closedList.Add(neighbourNode);
                        continue;
                    }

                    int tentativeGcost = currentNode.gCost + CalculateDistance(currentNode, neighbourNode);
                    if (tentativeGcost < neighbourNode.gCost)
                    {
                        neighbourNode.CameFromNode = currentNode;
                        neighbourNode.gCost = tentativeGcost;
                        neighbourNode.hCost = CalculateDistance(neighbourNode, endNode);
                        neighbourNode.CalculateFCost();

                        if (!openList.Contains(neighbourNode))
                        {
                            openList.Add(neighbourNode);
                        }
                    }
                }
            }
            // out of nodes
            return new List<Int2>() { };
        }
 
        private int CalculateDistance(PathNode start, PathNode end)
        {
            int xDistance = Math.Abs(start.x - end.x);
            int yDistance = Math.Abs(start.y - end.y);
            int remaining = Math.Abs(xDistance - yDistance);
            int minStrait = Math.Min(xDistance, yDistance);

            return minStrait * DIAGONAL_COST + STRAIGHT_COST * remaining;
        }

        // todo use binary tree
        private PathNode GetLowestFCostNode(List<PathNode> pathNodeList)
        {
            PathNode lowestCostNode = pathNodeList[0];
            for (int i = 1; i < pathNodeList.Count; i++)
            {
                if (pathNodeList[i].fCost < lowestCostNode.fCost)
                {
                    lowestCostNode = pathNodeList[i];
                }
            }
            return lowestCostNode;
        }

        private List<Int2> CalculatePath(PathNode endNode)
        {
            List<Int2> nodes = new List<Int2>
            {
                endNode.Pos
            };
            PathNode currentNode = endNode;
            while (currentNode.CameFromNode != null)
            {
                currentNode = currentNode.CameFromNode;
                nodes.Add(currentNode.Pos);
            }
            nodes.Remove(currentNode.Pos);
            nodes.Reverse();
            return nodes;
        }

        private List<PathNode> GetNeighbours(PathNode currentNode)
        {
            List<PathNode> neighbours = new List<PathNode>(8);
            int currentX = currentNode.x - 1;
            if (currentX >= 0)
            {
                // [X] [] []
                // [X] [] []
                // [X] [] []
                AddColumn(currentX, currentNode.y, neighbours);
            }
            currentX = currentNode.x + 1;
            if (currentX < buildings.Width)
            {
                // [] [] [X]
                // [] [] [X]
                // [] [] [X]
                AddColumn(currentX, currentNode.y, neighbours);
            }

            // [] [X] []
            // [] [ ] []
            // [] [X] []
            if (currentNode.y - 1 >= 0) neighbours.Add(buildings[currentNode.x, currentNode.y - 1]);
            if (currentNode.y + 1 < buildings.Height) neighbours.Add(buildings[currentNode.x, currentNode.y + 1]);
            return neighbours;
        }

        private void AddColumn(int x, int y, List<PathNode> neighbours)
        {
            neighbours.Add(buildings[x, y]);
            if (y - 1 >= 0) neighbours.Add(buildings[x, y - 1]);
            if (y + 1 < buildings.Height) neighbours.Add(buildings[x, y + 1]);
        }

        private bool InRange(Int2 pos)
        {
            return pos.X < buildings.Width && pos.X >= 0
                && pos.Y < buildings.Height && pos.Y >= 0;
        }
    }
}
