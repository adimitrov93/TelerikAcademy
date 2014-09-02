using System;
using System.Collections.Generic;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            bool result = true;

            if (hand.Cards.Count != 5)
            {
                result = false;
            }
            else
            {
                for (int i = 0; i < hand.Cards.Count - 2; i++)
                {
                    for (int j = (i + 1); j < hand.Cards.Count; j++)
                    {
                        if (hand.Cards[i].Equals(hand.Cards[j]))
                        {
                            result = false;

                            break;
                        }
                    }
                }
            }

            return result;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            bool result = true;

            if (IsValidHand(hand))
            {
                IList<ICard> cards = new List<ICard>(hand.Cards);
                ICard currentCard = cards[0];
                int numberOfDiffCards = 0;

                for (int i = 1; i < cards.Count; i++)
                {
                    if (currentCard.Face != cards[i].Face)
                    {
                        numberOfDiffCards++;

                        if (i == 1)
                        {
                            currentCard = cards[i];
                        }
                    }

                    if (numberOfDiffCards >= 2)
                    {
                        result = false;

                        break;
                    }
                }
            }
            else
            {
                throw new InvalidHandException("Invalid hand passed.");
            }

            return result;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            bool result = true;

            if (IsValidHand(hand))
            {
                for (int i = 0; i < hand.Cards.Count - 1; i++)
                {
                    if (hand.Cards[i].Suit != hand.Cards[i + 1].Suit)
                    {
                        result = false;

                        break;
                    }
                }
            }
            else
            {
                throw new InvalidHandException("Invalid hand passed.");
            }

            return result;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
