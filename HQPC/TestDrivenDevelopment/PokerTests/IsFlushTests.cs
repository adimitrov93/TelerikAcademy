namespace PokerTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class IsFlushTests
    {
        [TestMethod]
        public void TestWithValidFlush()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Six, CardSuit.Spades));
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ten, CardSuit.Spades));

            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            bool expectedResult = true;
            bool actualResult = checker.IsFlush(hand);

            Assert.AreEqual(expectedResult, actualResult, "IsFlush return false on valid flush hand.");
        }

        [TestMethod]
        public void TestWithInvalidFlush()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Six, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ten, CardSuit.Spades));

            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            bool expectedResult = false;
            bool actualResult = checker.IsFlush(hand);

            Assert.AreEqual(expectedResult, actualResult, "IsFlush return true on invalid flush hand.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidHandException))]
        public void TestWithInvalidHand()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ten, CardSuit.Spades));

            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            checker.IsFlush(hand);
        }
    }
}
