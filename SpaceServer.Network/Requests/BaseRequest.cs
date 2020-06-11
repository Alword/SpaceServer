using SpaceServer.Network.Abstractions;
using SpaceServer.Network.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceServer.Network.Requests
{
    public abstract class BaseRequest : BaseQuery
    {
        protected byte[] body;
        public override byte[] Body()
        {
            return body;
        }
    }
}
