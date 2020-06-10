using Serilog;
using SpaceServer.Business.Models;
using SpaceServer.Business.Packets;
using SpaceServer.Business.Properties;
using SpaceServer.Business.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

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



        public Entity Add(Entity entity)
        {
            Entity gameEntity = new Entity(NextEntityId(), entity);
            Entities.Add(gameEntity);
            Broadcast(new SpawnEntityQuery(new SpawnEntity()
            {
                typeId = gameEntity.EntityId,
                x = (int)(gameEntity.Transform.X * 100),
                y = (int)(gameEntity.Transform.Y * 100)
            })).Start();
            return gameEntity;
        }

        public void Destroy(uint entityId)
        {
            var e = Entities.SingleOrDefault(d => d.EntityId == entityId);
            if (e == null)
            {
                Log.Information($"{nameof(GameState)}.{nameof(Destroy)}.{Text.EntityNotFound}");
            }
            else
            {
                Entities.Remove(e);
                Log.Information($"{nameof(GameState)}.{nameof(Destroy)}.{e.EntityId}");
            }
        }
        private uint NextEntityId()
        {
            if (Entities.Any())
                return Entities.Max(e => e.EntityId + 1);
            return 0;
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
