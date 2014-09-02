namespace PokerTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class HandToStringTests
    {
        [TestMethod]
        public void ToStringWithNoCards()
        {
            Hand hand = new Hand(new List<ICard>());
            string expectedResult = "";
            string actualResult = hand.ToString();

            Assert.AreEqual(expectedResult, actualResult, "A hand with no cards does not stringify itself correctly.");
        }

        [TestMethod]
        public void ToStringWithOneCard()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Spades);
            List<ICard> cards = new List<ICard>();
            cards.Add(card);

            Hand hand = new Hand(cards);
            string expectedResult = "A♠";
            string actualResult = hand.ToString();

            Assert.AreEqual(expectedResult, actualResult, "A hand with one card does not stringify itself correctly.");
        }

        [TestMethod]
        public void ToStringWithFourCards()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));

            Hand hand = new Hand(cards);
            string expectedResult = "A♠ 2♥ 10♦ K♣";
            string actualResult = hand.ToString();

            Assert.AreEqual(expectedResult, actualResult, "A hand with four cards does not stringify itself correctly.");
        }

        [TestMethod]
        public void ToStringWithOneCardAddedTwice()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Spades);
            List<ICard> cards = new List<ICard>();
            cards.Add(card);
            cards.Add(card);

            Hand hand = new Hand(cards);
            string expectedResult = "A♠ A♠";
            string actualResult = hand.ToString();

            Assert.AreEqual(expectedResult, actualResult, "A hand with one card added twice does not stringify itself correctly.");
        }
    }
}
