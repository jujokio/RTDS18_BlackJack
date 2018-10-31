using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.ApiModels
{
    public class PlayerApiModel
    {
        public int PlayerId { get; set; }
        public int Funds { get; set; }
        public string PlayerName { get; set; }
        public Boolean CurrentlyPlaying { get; set; }
        public HandApiModel PlayerHand { get; set; }
        private string Ip { get; set; }
        private HttpClient Client { get; set; }


        public void giveCards(List<CardApiModel> cardList)
        {
           foreach (CardApiModel card in cardList)
           {
                PlayerHand.addCard(card);
           }
        }

        public async Task<int> SendMessageAsync(string message, int statuscode)
        {
            int result = -1;

            
            return result;
        }
    }

    public class DealerApiModel: PlayerApiModel
    {
        
    }
}