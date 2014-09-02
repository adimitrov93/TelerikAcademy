namespace PokerTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class IsValidHandTests
    {
        [TestMethod]
        public void TestWithValidHand()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));

            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            bool expectedResult = true;
            bool actualResult = checker.IsValidHand(hand);

            Assert.AreEqual(expectedResult, actualResult, "IsValidHand returns false to a valid hand.");
        }

        [TestMethod]
        public void TestWithValidHandWithDublicatingFaces()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));

            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            bool expectedResult = true;
            bool actualResult = checker.IsValidHand(hand);

            Assert.AreEqual(expectedResult, actualResult, "IsValidHand returns false to a valid hand with dublicating faces.");
        }

        // I know this test is covered by the first, but it's good to have it.
        [TestMethod]
        public void TestWithValidHandWithDublicatingSuits()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));

            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            bool expectedResult = true;
            bool actualResult = checker.IsValidHand(hand);

            Assert.AreEqual(expectedResult, actualResult, "IsValidHand returns false to a valid hand with dublicating suits.");
        }

        [TestMethod]
        public void TestWithHandWithLessThan5Cards()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));

            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            bool expectedResult = false;
            bool actualResult = checker.IsValidHand(hand);

            Assert.AreEqual(expectedResult, actualResult, "IsValidHand returns true to a hand with less than 5 cards.");
        }

        [TestMethod]
        public void TestWithHandWithMoreThan5Cards()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));

            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            bool expectedResult = false;
            bool actualResult = checker.IsValidHand(hand);

            Assert.AreEqual(expectedResult, actualResult, "IsValidHand returns true to a hand with more than 5 cards.");
        }

        [TestMethod]
        public void TestWithHandWithDublicatingCardsOneAfterAnother()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));

            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            bool expectedResult = false;
            bool actualResult = checker.IsValidHand(hand);

            Assert.AreEqual(expectedResult, actualResult, "IsValidHand returns true to a hand with 2 dublicating cards one after another.");
        }

        [TestMethod]
        public void TestWithHandWithDublicatingCardsMixedUp()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));

            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            bool expectedResult = false;
            bool actualResult = checker.IsValidHand(hand);

            Assert.AreEqual(expectedResult, actualResult, "IsValidHand returns true to a hand with 2 dublicating cards mixed up.");
        }

        [TestMethod]
        public void TestWithHandWithNoCards()
        {
            Hand hand = new Hand(new List<ICard>());
            PokerHandsChecker checker = new PokerHandsChecker();
            bool expectedResult = false;
            bool actualResult = checker.IsValidHand(hand);

            Assert.AreEqual(expectedResult, actualResult, "IsValidHand returns true to a hand with no cards.");
        }
    }
}
