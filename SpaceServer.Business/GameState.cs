using Serilog;
using SpaceServer.Business.Models;
using SpaceServer.Business.Properties;
using SpaceServer.Network.Packets;
using SpaceServer.Network.Queries;
using SpaceServer.Network.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using SpaceServer.Business.Extentions;

namespace SpaceServer.Business
{
    public class GameState
    {
        public List<Player> Players { get; private set; }
        public List<Entity> Entities { get; private set; }
        public Dictionary<string, uint> ConnPlayerId { get; private set; }
        public GameState()
        {
            Players = new List<Player>();
            Entities = new List<Entity>();
        }

        public async Task Broadcast(IQuery command)
        {
            foreach (Player player in Players)
            {
                await player.WebSocket.SendAsync(command.ToByteArray(), WebSocketMessageType.Binary, true, CancellationToken.None);
            }
        }
    }
}
