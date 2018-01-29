using Android.App;
using Android.Widget;
using Android.OS;
using CardsApp.core;
using System.Collections.Generic;
using System;
using System.Linq;

namespace CardsApp
{
    [Activity(Label = "CardsApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private TextView discard;
        private TextView remaining;
        private Button draw;
        private Button reset;
        private CardManager cardManager;
        private Card activeCard;
        private List<Card> cards;
        private List<Card> discardPile;

        private int howManyCardsDrawed;

        private TextView[] cardValues;
        private ImageView[] cardColors;
        private TextView cardSymbol;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);


            cardManager = new CardManager();
            cards = cardManager.getDeck();
            discardPile = new List<Card>();

            discard = FindViewById<TextView>(Resource.Id.drawed);
            remaining = FindViewById<TextView>(Resource.Id.remaining);
            draw = FindViewById<Button>(Resource.Id.draw);
            reset = FindViewById<Button>(Resource.Id.reset);

            activeCard = null;

            cardValues = new TextView[]
            {
                FindViewById<TextView>(Resource.Id.topValue),
                FindViewById<TextView>(Resource.Id.bottomValue),
            };

            cardColors = new ImageView[]
            {
                FindViewById<ImageView>(Resource.Id.topColor),
                FindViewById<ImageView>(Resource.Id.bottomColor),
            };

            cardSymbol = FindViewById<TextView>(Resource.Id.centerSymbol);

            draw.Click += drawACard;

            reset.Click += resetCards;

        }

        void drawACard(object sender, EventArgs e)
        {
            if(cards.Count() != 0)
            {
                activeCard = cards[0];
                discardPile.Add(activeCard);
                cards.RemoveAt(0);
                updateDisplay();
            }
        }

        void resetCards(object sender, EventArgs e)
        {
            cards = cardManager.getDeck();
            var rng = new Random();
            cards = cards.OrderBy(a => rng.Next()).ToList<Card>();
            activeCard = null;
            updateDisplay();
        }

        private void updateDisplay()
        {
            remaining.Text = cards.Count.ToString();
            discard.Text = discardPile.Count.ToString();
            updateCardDisplay();
        }

        private void updateCardDisplay()
        {
            if(activeCard == null)
            {
                displayDefaultCard();
            }
            else
            {
                foreach (TextView t in cardValues)
                {
                    t.SetTextColor(CardViewHelper.getCardColor(activeCard.Color));
                    t.Text = activeCard.Value;
                }
                foreach (ImageView t in cardColors)
                {
                    t.SetImageResource(CardViewHelper.GetCardResource(activeCard.Color));
                    t.SetColorFilter(CardViewHelper.getCardColor(activeCard.Color));
                }

                cardSymbol.SetTextColor(CardViewHelper.getCardColor(activeCard.Color));
                cardSymbol.Text = activeCard.Color;
                if (activeCard.Value == "K")
                {
                    cardSymbol.Text = cardSymbol.Text + "♔";
                }
                else if (activeCard.Value == "Q")
                {
                    cardSymbol.Text = cardSymbol.Text + "♕";
                }
                else if (activeCard.Value == "J")
                {
                    cardSymbol.Text = cardSymbol.Text + "♙";
                }
                else
                {
                    cardSymbol.Text = cardSymbol.Text + activeCard.Value;
                }
            }
            
        }


        private void displayDefaultCard()
        {
            foreach (TextView t in cardValues)
            {
                t.Text = "J";
            }
            cardSymbol.Text = "J";
        }
    }
}

