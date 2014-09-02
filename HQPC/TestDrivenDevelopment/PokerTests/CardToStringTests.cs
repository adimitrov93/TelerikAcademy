namespace PokerTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;
    using System;

    [TestClass]
    public class CardToStringTests
    {
        [TestMethod]
        public void ToStringOfAceOfSpades()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Spades);
            string expectedResult = "A♠";
            string actualResult = card.ToString();

            Assert.AreEqual(expectedResult, actualResult, "The ace of spades does not stringify itself correctly.");
        }

        [TestMethod]
        public void ToStringOfTwoOfHearts()
        {
            Card card = new Card(CardFace.Two, CardSuit.Hearts);
            string expectedResult = "2♥";
            string actualResult = card.ToString();

            Assert.AreEqual(expectedResult, actualResult, "The two of hearts does not stringify itself correctly.");
        }

        [TestMethod]
        public void ToStringOfTenOfDiamonds()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Diamonds);
            string expectedResult = "10♦";
            string actualResult = card.ToString();

            Assert.AreEqual(expectedResult, actualResult, "The ten of diamonds does not stringify itself correctly.");
        }

        [TestMethod]
        public void ToStringOfKingOfClubs()
        {
            Card card = new Card(CardFace.King, CardSuit.Clubs);
            string expectedResult = "K♣";
            string actualResult = card.ToString();

            Assert.AreEqual(expectedResult, actualResult, "The king of clubs does not stringify itself correctly.");
        }
    }
}