namespace CustomException
{
    using System;

    public class InvalidRangeException<T> : ApplicationException
    {
        // Constants
        private const string MsgFormatFor2ArgConstr = "The value must be from {0} to {1}";
        private const string MsgFormatFor3ArgConstr = "{0}, Start: {1}, End: {2}";

        // Constructors
        public InvalidRangeException(T start, T end)
            : base(string.Format(MsgFormatFor2ArgConstr, start, end))
        {
            this.Start = start;
            this.End = end;
        }

        public InvalidRangeException(string msg, T start, T end)
            : base(string.Format(MsgFormatFor3ArgConstr, msg, start, end))
        {
            this.Start = start;
            this.End = end;
        }

        // Properties
        public T Start { get; private set; }

        public T End { get; private set; }
    }
}
