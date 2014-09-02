namespace ArithmeticalComparsions
{
    using System;
    using System.Diagnostics;
    using System.Text;

    public static class MultiplicationComparsions
    {
        public const int NumberOfTests = 10000;

        public static string RunTests()
        {
            StringBuilder results = new StringBuilder();
            Stopwatch stopwatch = new Stopwatch();

            results.AppendLine("Multiplication comparsion");
            results.AppendLine(new string('-', 40));

            int intNumber = 23;
            int intResult = 1;

            stopwatch.Start();

            for (int i = 0; i < 10000; i++)
            {
                intResult *= intNumber;
            }

            stopwatch.Stop();
            results.AppendLine(string.Format("{0,-8} -> {1}", "int", stopwatch.Elapsed));

            long longNumber = 23;
            long longResult = 1;

            stopwatch.Start();

            for (int i = 0; i < 10000; i++)
            {
                longResult *= longNumber;
            }

            stopwatch.Stop();
            results.AppendLine(string.Format("{0,-8} -> {1}", "long", stopwatch.Elapsed));

            float floatNumber = 23f;
            float floatResult = 1;

            stopwatch.Start();

            for (int i = 0; i < 10000; i++)
            {
                floatResult *= floatNumber;
            }

            stopwatch.Stop();
            results.AppendLine(string.Format("{0,-8} -> {1}", "float", stopwatch.Elapsed));

            double doubleNumber = 23;
            double doubleResult = 1;

            stopwatch.Start();

            for (int i = 0; i < 10000; i++)
            {
                doubleResult *= doubleNumber;
            }

            stopwatch.Stop();
            results.AppendLine(string.Format("{0,-8} -> {1}", "double", stopwatch.Elapsed));

            decimal decimalNumber = 23m;
            decimal decimalResult = 1;

            stopwatch.Start();

            for (int i = 0; i < 10000; i++)
            {
                try
                {
                    decimalResult *= decimalNumber;
                }
                catch (OverflowException ex)
                {
                    decimalResult = 1;
                }
            }

            stopwatch.Stop();
            results.AppendLine(string.Format("{0,-8} -> {1}", "decimal", stopwatch.Elapsed));

            results.AppendLine(new string('-', 40));

            return results.ToString();
        }
    }
}
