using Serilog;
using SpaceServer.Properties;
using System;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace SpaceServer
{
    public class WSConnections
    {
        private ConcurrentDictionary<string, WebSocket> _sockets = new ConcurrentDictionary<string, WebSocket>();
        private ConcurrentDictionary<WebSocket, string> _connections = new ConcurrentDictionary<WebSocket, string>();

        public string AddSocket(WebSocket socket)
        {
            string connId = Guid.NewGuid().ToString();
            return AddSocket(socket, connId);
        }
        public string AddSocket(WebSocket socket, string connId)
        {
            _sockets.TryAdd(connId, socket);
            _connections.TryAdd(socket, connId);
            Log.Information($"{nameof(WSConnections)} {Text.AddSocket}: {connId}");
            return connId;
        }

        public async Task Remove(WebSocket socket, WebSocketCloseStatus status, string closeStatusDescription, CancellationToken token)
        {
            _connections.TryRemove(socket, out string connection);
            _sockets.TryRemove(connection, out _);
            await socket.CloseAsync(status, closeStatusDescription, token);
        }

        public async Task Remove(string connection, WebSocketCloseStatus status, string closeStatusDescription, CancellationToken token)
        {
            _sockets.TryRemove(connection, out WebSocket socket);
            _connections.TryRemove(socket, out _);
            await socket.CloseAsync(status, closeStatusDescription, token);
        }

        public ConcurrentDictionary<string, WebSocket> GetAllSockets()
        {
            return _sockets;
        }
    }
}
