using MetroNet;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace MetroNetTests
{
    public class Tests
    {
        List<Card> unsorted;
        List<Card> sortedAsc;
        List<Card> sortedDsc;

        [SetUp]
        public void Setup()
        {
            unsorted = new List<Card>()
            {
                new Card("Spades", 'A'),
                new Card("Hearts", 'A'),

                new Card("Clubs", '3'),
                new Card("Hearts", '7'),
            };

            sortedAsc = new List<Card>() {
                new Card("Clubs", '3'),
                new Card("Hearts", '7'),
                new Card("Hearts", 'A'),
                new Card("Spades", 'A')
            };

            //Shallow clone to reverse
            sortedDsc = sortedAsc.ToList();
            sortedDsc.Reverse();
        }

        [Test]
        public void AssertOrderAscending()
        {
            CollectionAssert.AreEqual(this.sortedAsc, CustomSorting.SortCards(this.unsorted));
        }

        [Test]
        public void AssertOrderDescending()
        {
            CollectionAssert.AreEqual(this.sortedDsc, CustomSorting.SortCards(this.unsorted, false));
        }
    }
}