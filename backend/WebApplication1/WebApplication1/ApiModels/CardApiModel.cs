using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.ApiModels
{
    public class CardApiModel
    { 
 
        public CardNameApiModel Name { get; set; }
        public CardSuitApiModel Suit { get; set; }
        public int Value { get; set; }

        public CardApiModel(CardNameApiModel v1, CardSuitApiModel v2, int v3)
        {
            this.Name = v1;
            this.Suit = v2;
            this.Value = v3;
        }

    }


    public class CardSuitApiModel
    {
        public static implicit operator CardSuitApiModel(string v)
        {
            return (CardSuitApiModel)v;
        }

        public enum CardSuit
        {
            Spades = 0,
            Diamonds = 1,
            Hearts = 2,
            Clubs = 3
        }
    }

    public class CardNameApiModel
    {
        public static implicit operator CardNameApiModel(string v)
        {
            return (CardNameApiModel)v;
        }

        public enum CardName
        {
            Ace = 1,
            Deuce = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13
        }
    }
}