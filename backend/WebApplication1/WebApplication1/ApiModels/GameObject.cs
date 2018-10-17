using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Helpers;

namespace WebApplication1.ApiModels
{
    public class GameObject
    {

        private DeckApiModel playdeck = new DeckApiModel();
        private List<PlayerApiModel> players = new List<PlayerApiModel>();
        private DealerApiModel dealer = new DealerApiModel();
        public bool Playing { get; set; }



        public void main()
        {
            this.playdeck.Restart();
            System.Diagnostics.Debug.Write(this.playdeck.DeckToString());


        }










    }
}