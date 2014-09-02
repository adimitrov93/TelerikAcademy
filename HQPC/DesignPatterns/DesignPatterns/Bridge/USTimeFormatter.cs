namespace Bridge
{
    using System;

    // The "ConcreteImplementor" class
    public class USTimeFormatter : ITimeFormatter
    {
        public string Format(DateTime time)
        {
            return (time.Hour % 12) + ":" + time.Minute + " " + (time.Hour <= 12 ? "AM" : "PM");
        }
    }
}
