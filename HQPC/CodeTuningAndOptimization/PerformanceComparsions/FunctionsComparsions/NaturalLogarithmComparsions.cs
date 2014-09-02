namespace FunctionsComparsions
{
    using System;
    using System.Diagnostics;
    using System.Text;

    public static class NaturalLogarithmComparsions
    {
        public const int NumberOfTests = 10000;

        public static string RunTests()
        {
            StringBuilder results = new StringBuilder();
            Stopwatch stopwatch = new Stopwatch();

            results.AppendLine("Natural logarithm comparsion");
            results.AppendLine(new string('-', 40));

            float floatNumber = 23f;

            stopwatch.Start();

            for (int i = 0; i < NumberOfTests; i++)
            {
                Math.Log(floatNumber, Math.E);
            }

            stopwatch.Stop();

            results.AppendLine(string.Format("{0,-8} -> {1}", "float", stopwatch.Elapsed));

            double doubleNumber = 23;

            stopwatch.Start();

            for (int i = 0; i < NumberOfTests; i++)
            {
                Math.Log(doubleNumber, Math.E);
            }

            stopwatch.Stop();

            results.AppendLine(string.Format("{0,-8} -> {1}", "double", stopwatch.Elapsed));

            decimal decimalNumber = 23m;

            stopwatch.Start();

            for (int i = 0; i < NumberOfTests; i++)
            {
                Math.Log((double)decimalNumber, Math.E);
            }

            stopwatch.Stop();

            results.AppendLine(string.Format("{0,-8} -> {1}", "decimal", stopwatch.Elapsed));

            results.AppendLine(new string('-', 40));

            return results.ToString();
        }
    }
}
