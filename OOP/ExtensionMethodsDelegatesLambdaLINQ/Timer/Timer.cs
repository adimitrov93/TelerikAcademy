namespace Timer
{
    using System;
    using System.Threading;

    public class Timer
    {
        // Constructor
        public Timer(uint delayInSecs, Action action)
        {
            this.Delay = (int)delayInSecs * 1000;
            this.InvokeMethod = action;
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    this.InvokeMethod();
                    Thread.Sleep(this.Delay);
                }
            });

            thread.Start();
        }

        // Properties
        public int Delay { get; private set; }

        public Action InvokeMethod { get; private set; }
    }
}