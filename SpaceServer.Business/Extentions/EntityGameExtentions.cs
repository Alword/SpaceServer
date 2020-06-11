using Serilog;
using SpaceServer.Business.Models;
using SpaceServer.Business.Properties;
using SpaceServer.Network.Packets;
using SpaceServer.Network.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceServer.Business.Extentions
{
    public static class EntityGameExtentions
    {
        public static Entity Add(this GameState state, Entity entity, string connId)
        {
            Entity gameEntity = new Entity(state.Entities.GenerateId(), entity);
            state.Entities.Add(gameEntity);
            state.Broadcast(new SpawnEntityQuery(new SpawnEntity()
            {
                typeId = gameEntity.Id,
                x = (int)(gameEntity.Transform.X * 100),
                z = (int)(gameEntity.Transform.Y * 100)
            }, state.ConnPlayerId[connId])).Start();
            return gameEntity;
        }

        public static void Destroy(this GameState state, uint entityId)
        {
            var e = state.Entities.SingleOrDefault(d => d.Id == entityId);
            if (e == null)
            {
                Log.Information($"{nameof(GameState)}.{nameof(Destroy)}.{Text.EntityNotFound}");
            }
            else
            {
                state.Entities.Remove(e);
                Log.Information($"{nameof(GameState)}.{nameof(Destroy)}.{e.Id}");
            }
        }
    }
}
