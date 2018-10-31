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

        public int PlayerId { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public List<PlayerApiModel> PlayerList { get; set; }
        public List<HandApiModel> HandList { get; set; }

        public GameMessageApiModel(PlayerApiModel player)
        {
            this.PlayerId = player.PlayerId;
            this.PlayerList.Add(player);
            this.HandList.Add(player.PlayerHand);
        }
    }
}