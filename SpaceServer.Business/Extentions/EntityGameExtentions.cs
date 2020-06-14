using Serilog;
using SpaceServer.Business.Models;
using SpaceServer.Business.Properties;
using System.Linq;

namespace SpaceServer.Business.Extentions
{
    public static class EntityGameExtentions
    {
        public static Entity Add(this GameState state, Entity entity, string connId)
        {
            int id = state.Entities.Values.GenerateId();
            Entity gameEntity = new Entity(id, entity);
            state.Entities.Add(id, gameEntity);
            return gameEntity;
        }

        public static void Destroy(this GameState state, int entityId)
        {
            if (state.Entities.ContainsKey(entityId))
            {
                state.Entities.Remove(entityId);
                Log.Information($"{nameof(GameState)}.{nameof(Destroy)}.{entityId}");
            }
            else
            {
                Log.Information($"{nameof(GameState)}.{nameof(Destroy)}.{Text.EntityNotFound}");
            }
        }
    }
}
