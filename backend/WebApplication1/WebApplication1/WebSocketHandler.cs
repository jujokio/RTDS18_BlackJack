using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Web.WebSockets;
using WebApplication1.ApiModels;

namespace WebApplication1
{
    public class ServerEventHandler : WebSocketHandler
    {
        public override void OnOpen()
        {
            base.Send("You connected to a WebSocket!");
            GameObject gameObject = new GameObject();
            gameObject.runGame();
        }

        public override void OnMessage(string message)
        {
            // Echo message
            base.OnMessage(message);
        }

        public override void OnClose()
        {
            // Free resources, close connections, etc.
            base.OnClose();
        }
    }
}
