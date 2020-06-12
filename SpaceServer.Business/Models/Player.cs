using SpaceServer.Network.Abstractions;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace SpaceServer.Business.Models
{
    public class Player : Uniq
    {
        public string ConnId { get; private set; }
        private WebSocket WebSocket { get; }
        public Player(string connId, WebSocket webSocket, uint playerId) : base(playerId)
        {
            this.WebSocket = webSocket;
            this.ConnId = connId;
        }

        public Task SendAsync(IQuery command)
        {
            var message = command.ToByteArray();
            return WebSocket.SendAsync(message, WebSocketMessageType.Binary, true, CancellationToken.None);
        }
    }
}
