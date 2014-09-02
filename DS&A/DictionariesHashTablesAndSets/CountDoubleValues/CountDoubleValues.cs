namespace CountDoubleValues
{
    using System;
    using System.Collections.Generic;

    public class CountDoubleValues
    {
        public static void Main()
        {
            double[] values = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            Dictionary<double, int> counts = new Dictionary<double, int>();

            foreach (var value in values)
            {
                if (counts.ContainsKey(value))
                {
                    counts[value]++;
                }
                else
                {
                    counts[value] = 1;
                }
            }

            foreach (var count in counts)
            {
                Console.WriteLine("{0} -> {1} {2}", count.Key, count.Value, count.Value > 1 ? "times" : "time");
            }
        }
    }
}