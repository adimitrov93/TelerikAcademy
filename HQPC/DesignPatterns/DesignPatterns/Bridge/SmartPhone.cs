namespace Bridge
{
    using System;

    // The "RefinedAbstraction" class
    public class SmartPhone : Clock
    {
        public SmartPhone(string phoneNumber, DateTime time, ITimeFormatter formatter)
            : base(time, formatter)
        {
            this.PhoneNumber = phoneNumber;
        }

        public string PhoneNumber { get; private set; }

        public override void ShowTime()
        {
            Console.WriteLine("SmartPhone time: " + this.formatter.Format(this.Time));
        }

        public void MakeCall(string phoneNumber)
        {
            Console.WriteLine("Calling {0}...", phoneNumber);
        }
    }
}
