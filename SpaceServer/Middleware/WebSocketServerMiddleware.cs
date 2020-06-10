using Microsoft.AspNetCore.Http;
using Serilog;
using SpaceServer.Business;
using SpaceServer.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaceServer.Middleware
{
    public class WebSocketServerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly WSConnections manager;
        private readonly List<CommandsHandler> servers;
        public WebSocketServerMiddleware(RequestDelegate next, WSConnections manager)
        {
            this.manager = manager;
            this.next = next;
            this.servers = new List<CommandsHandler>
            {
                new CommandsHandler(new GameState())
            };
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.WebSockets.IsWebSocketRequest)
            {
                WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
                string connId = manager.AddSocket(webSocket, context.Connection.Id);
                Log.Information($"{Text.WebSocketConnected} - {connId}");
                await SendConnIdAsync(webSocket, connId);

                await Receive(webSocket, async (result, buffer) =>
                {
                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        Log.Information($"Receive Text");
                        Log.Information($"Message: {Encoding.UTF8.GetString(buffer, 0, result.Count)}");
                        return;
                    }
                    if (result.MessageType == WebSocketMessageType.Binary)
                    {
                        // find user server
                        var commands = servers.First();
                        commands[buffer[0]].Invoke(buffer[1..]);
                    }
                    else if (result.MessageType == WebSocketMessageType.Close)
                    {
                        var closeStatus = result.CloseStatus ?? WebSocketCloseStatus.Empty;

                        await manager.Remove(context.Connection.Id, closeStatus, result.CloseStatusDescription, CancellationToken.None);

                        Log.Information($"{Text.WebSocketDisonnected} - {connId}");

                        return;
                    }
                });
            }
            else
            {
                Log.Information("Hello from 2nd Request Delegate - No WebSocket");
                await next(context);
            }
        }

        private async Task Receive(WebSocket socket, Action<WebSocketReceiveResult, byte[]> handleMessage)
        {
            var buffer = new byte[1024 * 4];

            while (socket.State == WebSocketState.Open)
            {
                var result = await socket.ReceiveAsync(buffer: new ArraySegment<byte>(buffer),
                                                       cancellationToken: CancellationToken.None);

                handleMessage(result, buffer);
            }
        }

        private async Task SendConnIdAsync(WebSocket webSocket, string connId)
        {
            var buffer = Encoding.UTF8.GetBytes(connId);
            await webSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}
