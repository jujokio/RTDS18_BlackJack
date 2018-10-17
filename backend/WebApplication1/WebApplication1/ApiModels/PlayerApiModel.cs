using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.ApiModels
{
    public class PlayerApiModel 
    {
        public int PlayerId { get; set; }
        public int Funds { get; set; }
        public string PlayerName { get; set; }
        public HandApiModel PlayerHand { get; set; }
    }

    public class DealerApiModel: PlayerApiModel
    {
        
    }
}