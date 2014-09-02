namespace Bridge
{
    using System;

    // The "ConcreteImplementor" class
    public class EUTimeFormatter : ITimeFormatter
    {
        public string Format(DateTime time)
        {
            return time.Hour + ":" + time.Minute + ":" + time.Second;
        }
    }
}
