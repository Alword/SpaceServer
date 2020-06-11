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

        public Entity Add(Entity entity, string connId)
        {
            Entity gameEntity = new Entity(Entities.GenerateId(), entity);
            Entities.Add(gameEntity);
            Broadcast(new SpawnEntityQuery(new SpawnEntity()
            {
                typeId = gameEntity.Id,
                x = (int)(gameEntity.Transform.X * 100),
                z = (int)(gameEntity.Transform.Y * 100)
            }, ConnPlayerId[connId])).Start();
            return gameEntity;
        }

        public void Destroy(uint entityId)
        {
            var e = Entities.SingleOrDefault(d => d.Id == entityId);
            if (e == null)
            {
                Log.Information($"{nameof(GameState)}.{nameof(Destroy)}.{Text.EntityNotFound}");
            }
            else
            {
                Entities.Remove(e);
                Log.Information($"{nameof(GameState)}.{nameof(Destroy)}.{e.Id}");
            }
        }

        private async Task Broadcast(IQuery command)
        {
            foreach (Player player in Players)
            {
                await player.WebSocket.SendAsync(command.ToByteArray(), WebSocketMessageType.Binary, true, CancellationToken.None);
            }
        }
    }
}
