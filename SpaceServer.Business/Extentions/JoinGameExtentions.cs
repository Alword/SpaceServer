using SpaceServer.Business.Models;
using System.Linq;
using System.Net.WebSockets;

namespace SpaceServer.Business.Extentions
{
    public static class JoinGameExtentions
    {
        public static void Join(this GameState state, string connId, WebSocket webSocket)
        {
            Player player = new Player(connId, webSocket, state.Players.GenerateId());
            state.Players.Add(player);
        }

        public static void Leave(this GameState state, string connId)
        {
            var player = state.Players.FirstOrDefault(d => d.ConnId == connId);
            if (player != null)
                state.Players.Remove(player);
        }
    }
}
