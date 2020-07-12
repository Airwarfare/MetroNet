using System;
using System.Collections.Generic;
using System.Linq;

namespace MetroNet
{

    public class Card
    {
        public static Dictionary<char, int> cardValues = new Dictionary<char, int>()
        {
            { '2', 2 },
            { '3', 3 },
            { '4', 4 },
            { '5', 5 },
            { '6', 6 },
            { '7', 7 },
            { '8', 8 },
            { '9', 9 },
            { 'J', 10 },
            { 'Q', 11 },
            { 'K', 12 },
            { 'A', 13 }
        };

        public static Dictionary<string, int> suitValues = new Dictionary<string, int>()
        {
            { "Hearts", 1 },
            { "Diamonds", 2 },
            { "Clubs", 3 },
            { "Spades", 4 }
        };

        public string suit { get; set; }
        public char value { get; set; }

        public Card(string suit, char value)
        {
            this.suit = suit;
            this.value = value;
        }

        public int GetCardValue()
        {
            return cardValues[this.value];
        }

        public int GetSuitValue()
        {
            return suitValues[this.suit];
        }

        public override string ToString()
        {
            return $"{this.value} of {this.suit}";
        }

        public override bool Equals(object obj)
        {
            return obj is Card card &&
                   suit == card.suit &&
                   value == card.value;
        }

        public override int GetHashCode()
        {
            var hashCode = -1742513846;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(suit);
            hashCode = hashCode * -1521134295 + value.GetHashCode();
            return hashCode;
        }
    }

    public class CustomSorting
    {
        public static void Main(string[] args) { }

        public static List<Card> SortCards(List<Card> cards, bool ascending = true)
        {
            Func<Card, int> cardValue = c => c.GetCardValue();
            Func<Card, int> suitValue = c => c.GetSuitValue();
            IOrderedEnumerable<Card> result = ascending ? cards.OrderBy(cardValue).ThenBy(suitValue) : cards.OrderByDescending(cardValue).ThenByDescending(suitValue);
            return result.ToList();
        }
    }
}
