﻿using Serilog;
using SpaceServer.Business.Models;
using SpaceServer.Business.Properties;
using SpaceServer.Network.Packets;
using SpaceServer.Network.Queries;
using SpaceServer.Network.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using SpaceServer.Business.Extentions;

namespace SpaceServer.Business
{
    public class GameState
    {
        public List<Player> Players { get; private set; }
        public List<Entity> Entities { get; private set; }
        public Dictionary<string, uint> ConnPlayerId { get; private set; }
        public GameState()
        {
            Players = new List<Player>();
            Entities = new List<Entity>();
            ConnPlayerId = new Dictionary<string, uint>();
        }

        public void Broadcast(IQuery command)
        {
            Task.Run(() =>
            {
                var players = Players.ToArray();
                Task[] sendTasks = new Task[Players.Count];

                for (int i = 0; i < players.Length; i++)
                {
                    sendTasks[i] = players[i].SendAsync(command);
                }
                Task.WaitAll(sendTasks);
            });
        }
    }
}
