using SpaceServer.Business.Abstractions;
using SpaceServer.Business.Commands;
using SpaceServer.Business.Extentions;
using SpaceServer.Network.Abstractions;
using System.Collections.Generic;
using System.Net.WebSockets;

namespace SpaceServer.Business
{
    public class ServerSDKListner
    {
        private readonly GameState gameState;
        private readonly Dictionary<byte, ICommand> commands;
        public ServerSDKListner(GameState gameState)
        {
            this.gameState = gameState;
            commands = new Dictionary<byte, ICommand>
            {
                {0x1,new SpawnEntityCommand(gameState)},
                {0x2,new SpawnEntityCommand(gameState)}
            };
        }

        public ICommand this[byte id]
        {
            get
            {
                if (commands.ContainsKey(id))
                {
                    return commands[id];
                }
                return EmptyCommand.Void;
            }
        }

        public void Join(string connId, WebSocket webSocket) => gameState.Join(connId, webSocket);
        public void Leave(string connId) => gameState.Leave(connId);
    }
}
