using System;
using System.Collections.Generic;
using System.Text;

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
