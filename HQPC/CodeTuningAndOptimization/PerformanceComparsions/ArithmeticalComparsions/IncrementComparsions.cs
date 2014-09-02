namespace ArithmeticalComparsions
{
    using System;
    using System.Diagnostics;
    using System.Text;

    public static class IncrementComparsions
    {
        public const int NumberOfTests = 10000;

        public static string RunTests()
        {
            StringBuilder results = new StringBuilder();
            Stopwatch stopwatch = new Stopwatch();

            results.AppendLine("Increment comparsion");
            results.AppendLine(new string('-', 40));

            int intResult = int.MinValue;

            stopwatch.Start();

            for (int i = 0; i < 10000; i++)
            {
                intResult++;
            }

            stopwatch.Stop();
            results.AppendLine(string.Format("{0,-8} -> {1}", "int", stopwatch.Elapsed));

            long longResult = long.MinValue;

            stopwatch.Start();

            for (int i = 0; i < 10000; i++)
            {
                longResult++;
            }

            stopwatch.Stop();
            results.AppendLine(string.Format("{0,-8} -> {1}", "long", stopwatch.Elapsed));

            float floatResult = float.MinValue;

            stopwatch.Start();

            for (int i = 0; i < 10000; i++)
            {
                floatResult++;
            }

            stopwatch.Stop();
            results.AppendLine(string.Format("{0,-8} -> {1}", "float", stopwatch.Elapsed));

            double doubleResult = double.MinValue;

            stopwatch.Start();

            for (int i = 0; i < 10000; i++)
            {
                doubleResult++;
            }

            stopwatch.Stop();
            results.AppendLine(string.Format("{0,-8} -> {1}", "double", stopwatch.Elapsed));

            decimal decimalResult = decimal.MinValue;

            stopwatch.Start();

            for (int i = 0; i < 10000; i++)
            {
                decimalResult++;
            }

            stopwatch.Stop();
            results.AppendLine(string.Format("{0,-8} -> {1}", "decimal", stopwatch.Elapsed));

            results.AppendLine(new string('-', 40));

            return results.ToString();
        }
    }
}
