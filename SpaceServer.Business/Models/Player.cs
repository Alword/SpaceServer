using System.Net.WebSockets;

namespace SpaceServer.Business.Models
{
    public class Player : Uniq
    {
        public string ConnId { get; private set; }
        public WebSocket WebSocket { get; private set; }
        public Player(string connId, WebSocket webSocket, uint playerId) : base(playerId)
        {
            this.WebSocket = webSocket;
            this.ConnId = connId;
        }
    }
}
