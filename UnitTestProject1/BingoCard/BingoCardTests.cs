using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CodeWarKata
{
    [TestFixture]
    public class BingoCardTests
    {
        [Test]
        public void CardHas24Numbers()
        {
            Assert.AreEqual(24, BingoCard.GetCard().Length);
        }

        [Test]
        public void EachNumberOnCardIsUnique()
        {
            var card = BingoCard.GetCard();
            Assert.AreEqual(card.Length, card.ToList().Distinct().Count());
        }
    }
}
