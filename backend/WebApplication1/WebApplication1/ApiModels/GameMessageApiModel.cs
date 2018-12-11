using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.ApiModels
{
    public class GameMessageApiModel //: HttpContent
    {

        public Guid PlayerId { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public List<PlayerApiModel> PlayerList { get; set; }
        public List<HandApiModel> HandList { get; set; }

        public GameMessageApiModel(PlayerApiModel player)
        {
            PlayerList = new List<PlayerApiModel>();
            HandList = new List<HandApiModel>();

            PlayerId = player.PlayerId;
            PlayerList.Add(player);
            HandList.Add(player.PlayerHand);
        }

        public GameMessageApiModel()
        {
            PlayerList = new List<PlayerApiModel>();
            HandList = new List<HandApiModel>();

        }

        internal string ToDisplay()
        {
            string result = "";
            result += "playerId: "+ PlayerId + ", status: "+Status+  "\r\n";
            result += "Message: " + Message+ "\r\n";

            foreach (PlayerApiModel p in PlayerList)
            {
                result += p.PlayerName + ": " + p.PlayerHand.HandToDisplay()+ "\r\n";
            }


            return result;
        }
    }
}