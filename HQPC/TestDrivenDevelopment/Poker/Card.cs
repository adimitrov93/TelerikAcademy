namespace Poker
{
    using System;
    using System.Text;

    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            switch (this.Face)
            {
                case CardFace.Two:
                    result.Append("2");
                    break;
                case CardFace.Three:
                    result.Append("3");
                    break;
                case CardFace.Four:
                    result.Append("4");
                    break;
                case CardFace.Five:
                    result.Append("5");
                    break;
                case CardFace.Six:
                    result.Append("6");
                    break;
                case CardFace.Seven:
                    result.Append("7");
                    break;
                case CardFace.Eight:
                    result.Append("8");
                    break;
                case CardFace.Nine:
                    result.Append("9");
                    break;
                case CardFace.Ten:
                    result.Append("10");
                    break;
                case CardFace.Jack:
                    result.Append("J");
                    break;
                case CardFace.Queen:
                    result.Append("Q");
                    break;
                case CardFace.King:
                    result.Append("K");
                    break;
                case CardFace.Ace:
                    result.Append("A");
                    break;
            }

            switch (this.Suit)
            {
                case CardSuit.Clubs:
                    result.Append("♣");
                    break;
                case CardSuit.Diamonds:
                    result.Append("♦");
                    break;
                case CardSuit.Hearts:
                    result.Append("♥");
                    break;
                case CardSuit.Spades:
                    result.Append("♠");
                    break;
            }

            return result.ToString();
        }

        public override bool Equals(object obj)
        {
            Card otherCard = obj as Card;

            // If parsing is successfull
            if (otherCard != null)
            {
                if ((this.Face == otherCard.Face) && (this.Suit == otherCard.Suit))
                {
                    return true;
                }
            }

            return false;
        }
    }
}