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

        public int SendMessageAsync(GameMessageApiModel message)
        {
            int result = -1;
            //HttpContent payload = message;

            //HttpResponseMessage response = await Client.PostAsync(this.Ip, );
            
            return result;
        }
    }

    public class DealerApiModel: PlayerApiModel
    {
        
    }
}