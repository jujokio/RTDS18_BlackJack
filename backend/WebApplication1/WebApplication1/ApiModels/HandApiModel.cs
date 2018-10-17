using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.ApiModels
{
    public class HandApiModel
    {
        public List<CardApiModel> Hand { get; set; }
        public int TotalValue { get; set; }


        public void addCard(CardApiModel card)
        {
            Hand.Add(card);
            TotalValue += card.Value;

        }
    }
}