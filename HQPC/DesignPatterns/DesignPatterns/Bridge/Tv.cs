namespace Bridge
{
    using System;

    // The "RefinedAbstraction" class
    public class Tv : Clock
    {
        private readonly int startOnChannel;

        public Tv(int startOnChannel, DateTime time, ITimeFormatter formatter)
            : base(time, formatter)
        {
            this.startOnChannel = startOnChannel;
        }

        public override void ShowTime()
        {
            Console.WriteLine("TV time: " + this.formatter.Format(this.Time));
        }

        public void Start()
        {
            Console.WriteLine("TV started on channel {0}.", this.startOnChannel);
        }
    }
}
