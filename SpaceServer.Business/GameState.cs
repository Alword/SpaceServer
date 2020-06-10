using SpaceServer.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;

namespace SpaceServer.Business
{
    public class GameState
    {
        public List<Player> Players { get; private set; }
        public List<Entity> Entities { get; private set; }
        public GameState()
        {
            Players = new List<Player>();
            Entities = new List<Entity>();
        }

        public void Join(string connId, WebSocket webSocket)
        {
            Player player = new Player(connId, webSocket);
            Players.Add(player);
        }

        public void Leave(string connId)
        {
            var player = Players.FirstOrDefault(d => d.ConnId == connId);
            if (player != null)
                Players.Remove(player);
        }
    }
}
