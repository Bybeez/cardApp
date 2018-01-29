using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CardsApp.core
{
    class CardManager : List<Card>
    {
        private string[] REF_VALUES = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        public static readonly string[] REF_FAMILIES = new string[] { "♦", "♥", "♣", "♠" };
        private List<Card> deck;

        public CardManager()
        {
            deck = new List<Card>();
            init();
        }

        private void init()
        {
            foreach (string value in REF_VALUES)
            {
                foreach (string color in REF_FAMILIES)
                {
                    this.deck.Add(new Card
                    {
                        Value = value,
                        Color = color,
                    });
                }
            }
        }

        public List<Card> getDeck()
        {
            return this.deck.ToList();
        }
    }
}