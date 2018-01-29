using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CardsApp.core
{
    public static class CardViewHelper
    {
        public static readonly Dictionary<string, int> CardToRessource = new Dictionary<string, int>
        {
            {CardManager.REF_FAMILIES[0], Resource.Drawable.diamond},
            {CardManager.REF_FAMILIES[1], Resource.Drawable.heart },
            {CardManager.REF_FAMILIES[2], Resource.Drawable.clover },
            {CardManager.REF_FAMILIES[3], Resource.Drawable.spades }
        };

        public static int GetCardResource(string family)
        {
            if (CardToRessource.ContainsKey(family))
            {
                return CardToRessource[family];
            }
            else
            {
                return 0;
            }
        }

        public static Android.Graphics.Color getCardColor(string family)
        {
            Color c = Color.Black;
            if(family == CardManager.REF_FAMILIES[0] || family == CardManager.REF_FAMILIES[1])
            {
                c = Color.Red;
            }
            return c;
        }
    }
}