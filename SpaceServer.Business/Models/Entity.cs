using SpaceServer.Mathematic;

namespace SpaceServer.Business.Models
{
    public class Entity : Uniq
    {
        public int TypeId { get; set; }
        public Float3 Transform { get; set; }

        public Entity(int id, Entity entity) : base(id)
        {
            TypeId = entity.TypeId;
            Transform = entity.Transform;
        }

        public Entity() : base(0)
        {

        }
    }
}
