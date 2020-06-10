﻿using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;

namespace SpaceServer.Business.Models
{
    public class Player
    {
        public string ConnId { get; private set; }
        public WebSocket WebSocket { get; private set; }
        public Player(string connId, WebSocket webSocket)
        {
            this.ConnId = connId;
            this.WebSocket = webSocket;
        }
    }
}
