using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.ApiModels;

namespace WebApplication1.Controllers
{
    [Route("BlackJack")]
    [ApiController]
    public class BlackJackMain: ControllerBase
    {
        public static List<ChatApiModel> Chat = new List<ChatApiModel>();
        public static List<GameObject> listOfGames = new List<GameObject>();

        public static void Main(string[] args)
        {

            
            GameObject go = new GameObject();
            go.main();
            listOfGames.Add(go);
            //int i = 0;
            //while (i <= 3)
            //{
            //    System.Diagnostics.Debug.WriteLine("start new game");
            //    go.main();
            //    go.runGame();

            //    i++;
            //}
            //System.Diagnostics.Debug.WriteLine("ended");


        }

        // GET api/values
        [HttpGet]
        public ActionResult<List<GameObject>> Get()
        {
            return listOfGames;
        }

        [HttpPost("{playername}")]
        public ActionResult<GameObject> Join(string playername)
        {
            if (listOfGames == null || listOfGames.Count == 0)
            {
                listOfGames.Add(new GameObject());
            }
            foreach (GameObject game in listOfGames)
            {
                try
                {
                    game.JoinGame(playername);
                    return game;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("not able to join, " + e.ToString());
                    continue;
                }
            }
            return null;

        }


    }
}
