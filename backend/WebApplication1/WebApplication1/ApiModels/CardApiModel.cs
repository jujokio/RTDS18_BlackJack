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

        public CardApiModel(string v1, string v2, int v3)
        {
            this.Name = new CardNameApiModel(v1);
            this.Suit = new CardSuitApiModel(v2);
            this.Value = v3;
        }

        public string ToDisplay()
        {
            return Name.name + " of " + Suit.name;
        }

    }


    public class CardSuitApiModel
    {
        public int value;
        public string name;

        public CardSuitApiModel(string v)
        {

            if (v == "Spades")
            {
                name = v;
                value = 0;
            }
            else if (v == "Diamonds")
            {
                name = v;
                value = 1;
            }
            else if (v == "Hearts")
            {

                name = v;
                value = 2;
            }
            else if(v == "Clubs")
            {
                name = v;
                value = 3;
            }
            else
            {
                throw new Exception("WTF!!! suit is crazy: "+v);
            }
        }

        //public enum CardSuit
        //{
        //    Spades = 0,
        //    Diamonds = 1,
        //    Hearts = 2,
        //    Clubs = 3
        //}
    }

    public class CardNameApiModel
    {
        public int value;
        public string name;

        public  CardNameApiModel(string v)
        {
            name = v;
            value = CardNameToInt(v);
        }

        private int CardNameToInt(string v)
        {
            if (v == "Ace")
            {
                return 1;
            }
            else if (v == "Two")
            {
                return 2;
            }
            else if (v == "Three")
            {
                return 3;
            }
            else if (v == "Four")
            {
                return 4;
            }
            else if (v == "Five")
            {
                return 5;
            }
            else if (v == "Six")
            {
                return 6;
            }
            else if (v == "Seven")
            {
                return 7;
            }
            else if (v == "Eight")
            {
                return 8;
            }
            else if (v == "Nine")
            {
                return 9;
            }
            else if (v == "Ten")
            {
                return 10;
            }
            else if (v == "Jack")
            {
                return 11;
            }
            else if (v == "Queen")
            {
                return 12;
            }
            else if (v == "King")
            {
                return 13;
            }
            else
            {
                throw new Exception("WTF!? This card is crazy: " + v);
            }
        }

        //public enum CardName
        //{
        //    Ace = 1,
        //    Deuce = 2,
        //    Three = 3,
        //    Four = 4,
        //    Five = 5,
        //    Six = 6,
        //    Seven = 7,
        //    Eight = 8,
        //    Nine = 9,
        //    Ten = 10,
        //    Jack = 11,
        //    Queen = 12,
        //    King = 13
        //}
    }
}