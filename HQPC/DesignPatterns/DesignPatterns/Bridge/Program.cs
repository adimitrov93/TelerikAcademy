namespace Bridge
{
    using System;

    public class Program
    {
        public static void Main()
        {
            ITimeFormatter implementor;
            Clock abstraction;

            implementor = new EUTimeFormatter();

            abstraction = new SmartPhone("0123456789", DateTime.Now, implementor);
            abstraction.ShowTime();

            abstraction = new Tv(12, DateTime.Now, implementor);
            abstraction.ShowTime();

            implementor = new USTimeFormatter();

            abstraction = new SmartPhone("9876543210", DateTime.Now, implementor);
            abstraction.ShowTime();

            abstraction = new Tv(21, DateTime.Now, implementor);
            abstraction.ShowTime();
        }
    }
}
