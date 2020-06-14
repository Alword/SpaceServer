using SpaceServer.Business.Models;
using SpaceServer.Network.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceServer.Business
{
    public class GameState
    {
        public List<Player> Players { get; private set; }
        public List<Entity> Entities { get; private set; }
        public Dictionary<string, int> ConnPlayerId { get; private set; }
        public Pathfinder Terrain { get; private set; }
        public GameState()
        {
            Players = new List<Player>();
            Entities = new List<Entity>();
            ConnPlayerId = new Dictionary<string, int>();
            Terrain = new Pathfinder(100, 100);
        }

        public void Broadcast(IQuery command)
        {
            Task.Run(() =>
            {
                var players = Players.ToArray();
                Task[] sendTasks = new Task[Players.Count];

                for (int i = 0; i < players.Length; i++)
                {
                    sendTasks[i] = players[i].SendAsync(command);
                }
                Task.WaitAll(sendTasks);
            });
        }
    }
}
