//Write an expression that calculates trapezoid's area by given sides a and b and height h.

using System;
using System.Globalization;
using System.Threading;

class TrapezoidsArea
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Enter trapezoid's first base: ");
        float a = float.Parse(Console.ReadLine());
        Console.Write("Enter trapezoid's second base: ");
        float b = float.Parse(Console.ReadLine());
        Console.Write("Enter trapezoid's altitude: ");
        float h = float.Parse(Console.ReadLine());

        Console.WriteLine("Trapezoid's area is {0} square mm.", ((a + b) / 2) * h);
    }
}