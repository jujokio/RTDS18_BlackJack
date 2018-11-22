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

        public Guid PlayerId { get; set; }
        public int Funds { get; set; }
        public string PlayerName { get; set; }
        public bool CurrentlyPlaying { get; set; }
        public bool QuitGame { get; set; }
        public HandApiModel PlayerHand { get; set; }
        private string Ip { get; set; }
        private HttpClient Client { get; set; }
        public bool Busted { get; set; }

        public PlayerApiModel()
        {
            this.QuitGame = false;
            this.CurrentlyPlaying = false;
            this.Funds = -1;
            this.PlayerId = Guid.NewGuid();
        }

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