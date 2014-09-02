namespace Poker
{
    using System;

    public class InvalidHandException : ApplicationException
    {
        public InvalidHandException(string message)
            : base(message)
        {
        }
    }
}
