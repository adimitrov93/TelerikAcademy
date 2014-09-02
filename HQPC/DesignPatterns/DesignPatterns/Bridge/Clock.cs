namespace Bridge
{
    using System;

    // The "Abstraction" class
    public abstract class Clock
    {
        protected ITimeFormatter formatter;

        public Clock(DateTime time, ITimeFormatter formatter)
        {
            this.Time = time;
            this.formatter = formatter;
        }

        public DateTime Time { get; set; }

        public abstract void ShowTime();
    }
}
