using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceServer.Business.Queries
{
    interface IQuery
    {
        public byte QueryId { get; }
        public byte[] Query();
        public byte[] ToByteArray();
    }
}
