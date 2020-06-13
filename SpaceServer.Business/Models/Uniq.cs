namespace SpaceServer.Business.Models
{
    public class Uniq
    {
        public uint Id { get; private set; }

        public Uniq(uint id)
        {
            this.Id = id;
        }
    }
}
