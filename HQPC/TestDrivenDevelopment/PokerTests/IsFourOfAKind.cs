namespace PokerTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class IsFourOfAKind
    {
        [TestMethod]
        public void TestWithValidFourOfAKindHandWithArrangedCards()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ten, CardSuit.Spades));

            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            bool expectedResult = true;
            bool actualResult = checker.IsFourOfAKind(hand);

            Assert.AreEqual(expectedResult, actualResult, "IsFourOfAKind return false on valid four of a kind hand.");
        }

        [TestMethod]
        public void TestWithValidFourOfAKindHandWithMixedCards()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ten, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));

            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            bool expectedResult = true;
            bool actualResult = checker.IsFourOfAKind(hand);

            Assert.AreEqual(expectedResult, actualResult, "IsFourOfAKind return false on valid four of a kind hand.");
        }

        [TestMethod]
        public void TestWithValidFourOfAKindHandStartingWithTheDifferentCard()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ten, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));

            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            bool expectedResult = true;
            bool actualResult = checker.IsFourOfAKind(hand);

            Assert.AreEqual(expectedResult, actualResult, "IsFourOfAKind return false on valid four of a kind hand starting with the different card.");
        }

        [TestMethod]
        public void TestWithInvalidFourOfAKindHand()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ten, CardSuit.Spades));

            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            bool expectedResult = false;
            bool actualResult = checker.IsFourOfAKind(hand);

            Assert.AreEqual(expectedResult, actualResult, "IsFourOfAKind return true on invalid four of a kind hand.");
        }

        [TestMethod]
        public void TestWithInvalidFourOfAKindHandWithOnlyTwoFaces()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));

            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            bool expectedResult = false;
            bool actualResult = checker.IsFourOfAKind(hand);

            Assert.AreEqual(expectedResult, actualResult, "IsFourOfAKind return true on invalid four of a kind hand that contains only two different faces.");
        }

        [TestMethod]
        public void TestWithInvalidFourOfAKindHandWithOnlyTwoFacesStartingWithSecondFace()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));

            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            bool expectedResult = false;
            bool actualResult = checker.IsFourOfAKind(hand);

            Assert.AreEqual(expectedResult, actualResult, "IsFourOfAKind return true on invalid four of a kind hand that contains only two different faces.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidHandException))]
        public void TestWithInvalidHand()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));

            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            checker.IsFourOfAKind(hand);
        }
    }
}
