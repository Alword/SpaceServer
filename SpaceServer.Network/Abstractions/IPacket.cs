using System.Net.Http.Headers;

namespace SpaceServer.Network.Abstractions
{
    public interface IPacket
    {
        byte[] ToByteArray();
        bool TryParse(byte[] buf);
        bool TryRead(ref byte[] buf);
    }
}
