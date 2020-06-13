using SpaceServer.Network.Abstractions;
using SpaceServer.Network.Queries;

namespace SpaceServer.Network.Requests
{
    public abstract class BaseRequest : BaseQuery, IRequest
    {
        protected byte[] body;
        public override byte[] Body()
        {
            return body;
        }
    }
}
