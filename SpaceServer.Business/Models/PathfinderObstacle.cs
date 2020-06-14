using SpaceServer.Mathematic;

namespace SpaceServer.Business.Models
{
    public partial class Pathfinder
    {
        public bool AddObstacle(params Int2[] positions)
        {
            PathNode[] nodes = new PathNode[positions.Length];

            for (int i = 0; i < positions.Length; i++)
            {
                var pos = positions[i];
                if (!InRange(pos)) return false;

                nodes[i] = buildings[positions[i]];

                if (!nodes[i].IsEmpty) return false;
            }

            foreach (var node in nodes)
            {
                node.IsEmpty = false;
            }
            return true;
        }

        public void RemoveObstacle(params Int2[] positions)
        {
            foreach (var pos in positions)
            {
                if (InRange(pos))
                {
                    buildings[pos].IsEmpty = false;
                }
            }
        }
    }
}
