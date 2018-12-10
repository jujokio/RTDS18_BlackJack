using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Helpers;


namespace WebApplication1.ApiModels
{
    public class DeckApiModel
    {
        public List<CardApiModel> Deck { get; set;}
        public List<CardApiModel> UsedCards { get; set; }


        public List<CardApiModel> Draw(int numberOfDraws)
        {
            List<CardApiModel> Drawed = new List<CardApiModel>();
            for (int i=0;i<numberOfDraws;i++)
            {
                int index = CommonHelper.GetRandom(1, Deck.Count);
                CardApiModel draw = this.Deck.ElementAt(index);
                this.UsedCards.Add(draw);
                this.Deck.RemoveAt(index);
                Drawed.Add(draw);
            }
            return Drawed;
        }

        public void Restart()
        {
            this.Deck = new List<CardApiModel>();
            this.UsedCards = new List<CardApiModel>();

            this.Deck.Add(new CardApiModel("Ace", "Hearts", 11));
            this.Deck.Add(new CardApiModel("Two", "Hearts", 2));
            this.Deck.Add(new CardApiModel("Three", "Hearts", 3));
            this.Deck.Add(new CardApiModel("Four", "Hearts", 4));
            this.Deck.Add(new CardApiModel("Five", "Hearts", 5));
            this.Deck.Add(new CardApiModel("Six", "Hearts", 6));
            this.Deck.Add(new CardApiModel("Seven", "Hearts", 7));
            this.Deck.Add(new CardApiModel("Eight", "Hearts", 8));
            this.Deck.Add(new CardApiModel("Nine", "Hearts", 9));
            this.Deck.Add(new CardApiModel("Ten", "Hearts", 10));
            this.Deck.Add(new CardApiModel("Jack", "Hearts", 10));
            this.Deck.Add(new CardApiModel("Queen", "Hearts", 10));
            this.Deck.Add(new CardApiModel("King", "Hearts", 10));
            this.Deck.Add(new CardApiModel("Ace", "Diamonds", 11));
            this.Deck.Add(new CardApiModel("Two", "Diamonds", 2));
            this.Deck.Add(new CardApiModel("Three", "Diamonds", 3));
            this.Deck.Add(new CardApiModel("Four", "Diamonds", 4));
            this.Deck.Add(new CardApiModel("Five", "Diamonds", 5));
            this.Deck.Add(new CardApiModel("Six", "Diamonds", 6));
            this.Deck.Add(new CardApiModel("Seven", "Diamonds", 7));
            this.Deck.Add(new CardApiModel("Eight", "Diamonds", 8));
            this.Deck.Add(new CardApiModel("Nine", "Diamonds", 9));
            this.Deck.Add(new CardApiModel("Ten", "Diamonds", 10));
            this.Deck.Add(new CardApiModel("Jack", "Diamonds", 10));
            this.Deck.Add(new CardApiModel("Queen", "Diamonds", 10));
            this.Deck.Add(new CardApiModel("King", "Diamonds", 10));
            this.Deck.Add(new CardApiModel("Ace", "Clubs", 11));
            this.Deck.Add(new CardApiModel("Two", "Clubs", 2));
            this.Deck.Add(new CardApiModel("Three", "Clubs", 3));
            this.Deck.Add(new CardApiModel("Four", "Clubs", 4));
            this.Deck.Add(new CardApiModel("Five", "Clubs", 5));
            this.Deck.Add(new CardApiModel("Six", "Clubs", 6));
            this.Deck.Add(new CardApiModel("Seven", "Clubs", 7));
            this.Deck.Add(new CardApiModel("Eight", "Clubs", 8));
            this.Deck.Add(new CardApiModel("Nine", "Clubs", 9));
            this.Deck.Add(new CardApiModel("Ten", "Clubs", 10));
            this.Deck.Add(new CardApiModel("Jack", "Clubs", 10));
            this.Deck.Add(new CardApiModel("Queen", "Clubs", 10));
            this.Deck.Add(new CardApiModel("King", "Clubs", 10));
            this.Deck.Add(new CardApiModel("Ace", "Spades", 11));
            this.Deck.Add(new CardApiModel("Two", "Spades", 2));
            this.Deck.Add(new CardApiModel("Three", "Spades", 3));
            this.Deck.Add(new CardApiModel("Four", "Spades", 4));
            this.Deck.Add(new CardApiModel("Five", "Spades", 5));
            this.Deck.Add(new CardApiModel("Six", "Spades", 6));
            this.Deck.Add(new CardApiModel("Seven", "Spades", 7));
            this.Deck.Add(new CardApiModel("Eight", "Spades", 8));
            this.Deck.Add(new CardApiModel("Nine", "Spades", 9));
            this.Deck.Add(new CardApiModel("Ten", "Spades", 10));
            this.Deck.Add(new CardApiModel("Jack", "Spades", 10));
            this.Deck.Add(new CardApiModel("Queen", "Spades", 10));
            this.Deck.Add(new CardApiModel("King", "Spades", 10));
        }

        public string DeckToString()
        {
            string temp ="";
            foreach (CardApiModel c in Deck)
            {
                temp += c.ToDisplay() + ", ";
            }
            return temp;
        }

        public string UsedCardsToString()
        {
            return UsedCards.ToString();
        }
    }
}