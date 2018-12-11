using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;
using Microsoft.Web.WebSockets;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.ApiModels;

namespace WebApplication1
{
    public class ServerEventHandler : WebSocketHandler
    {
        [HttpGet]
        public ActionResult<List<GameObject>> Get()
        {
            return Program.listOfGames;
        }

        public override void OnOpen()
        {
            base.Send("You connected to a WebSocket!");

            // Check if running game exist
            // Join existing game or init new game

            string playername = "user1234";

            if(Program.listOfGames == null)
            {
                Program.listOfGames.Add(new GameObject());
            }
            foreach(GameObject game in Program.listOfGames)
            {
                try
                {
                    game.JoinGame(playername);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("not able to join, " + e.ToString());
                    continue;
                }
            }
           
            
        
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
