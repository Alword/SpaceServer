using SpaceServer.Mathematic;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceServer.Business.Models
{
    public class Entity
    {
        public uint EntityId { get; private set; }
        public int TypeId { get; set; }
        public Float3 Transform { get; set; }

        public Entity()
        {

        }

        public Entity(uint id, Entity entity) 
        {
            EntityId = id;
            TypeId = entity.TypeId;
            Transform = entity.Transform;
        }
    }
}
