using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;
using Microsoft.Web.WebSockets;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.ApiModels;
using WebApplication1.Controllers;

namespace WebApplication1
{
    public class ServerEventHandler : WebSocketHandler
    {
        [HttpGet]
        public ActionResult<List<GameObject>> Get()
        {
            return BlackJackMain.listOfGames;
        }

        public override void OnOpen()
        {
            base.Send("You connected to a WebSocket!");

            // Check if running game exist
            // Join existing game or init new game

            string playername = "user1234";

            if(BlackJackMain.listOfGames == null)
            {
                BlackJackMain.listOfGames.Add(new GameObject());
            }
            foreach(GameObject game in BlackJackMain.listOfGames)
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
