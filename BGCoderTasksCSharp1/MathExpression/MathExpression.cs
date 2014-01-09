using System;
using System.Globalization;
using System.Threading;

class MathExpression
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        decimal n = decimal.Parse(Console.ReadLine());
        decimal m = decimal.Parse(Console.ReadLine());
        decimal p = decimal.Parse(Console.ReadLine());

        decimal constNumerator = 1337m, constDenominator = 128.523123123m;

        decimal numerator = (n * n) + (1 / (m * p)) + constNumerator;
        decimal denominator = n - (constDenominator * p);
        decimal vtoroSubiraemo = (decimal)Math.Sin((int)m % 180);
        decimal result = (numerator / denominator) + vtoroSubiraemo;

        Console.WriteLine("{0:F6}", result);
    }
}