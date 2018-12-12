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

        public static void AddGame()
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

        // GET api/values
        [HttpGet("{playername}")]
        public ActionResult<List<PlayerApiModel>> Get(string playername)
        {
            if (listOfGames == null || listOfGames.Count == 0)
            {
                AddGame();
                foreach (GameObject game in listOfGames)
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
            List<PlayerApiModel> plaers = listOfGames[0].getPlayers();
            return plaers;
        }

        [HttpPost("{playername}")]
        public ActionResult<PlayerApiModel> Join(string playername)
        {
            if (listOfGames == null || listOfGames.Count == 0)
            {
                AddGame();
            }
            foreach (GameObject game in listOfGames)
            {
                try
                {
                    Guid playerGuid = game.JoinGame(playername);
                    return game.getSinglePlayer(playerGuid);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("not able to join, " + e.ToString());
                    AddGame();
                    Join(playername);
                }
            }
            return null;

        }


    }
}
