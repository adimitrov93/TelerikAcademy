namespace Timer
{
    using System;

    public class TimerTest
    {
        public static void Main()
        {
            Timer timer1 = new Timer(2, SampleMethod1);
            Timer timer2 = new Timer(5, SampleMethod2);
        }

        public static void SampleMethod1()
        {
            Console.WriteLine("Sample method 1 started!");
        }

        public static void SampleMethod2()
        {
            Console.WriteLine("Sample method 2 started!");
        }
    }
}