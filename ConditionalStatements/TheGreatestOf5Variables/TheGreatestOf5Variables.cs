//Write a program that finds the greatest of given 5 variables.

using System;
using System.Globalization;
using System.Threading;

class TheGreatestOf5Variables
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Enter a number: ");
        float a = float.Parse(Console.ReadLine());

        Console.Write("Enter a number: ");
        float b = float.Parse(Console.ReadLine());

        Console.Write("Enter a number: ");
        float c = float.Parse(Console.ReadLine());

        Console.Write("Enter a number: ");
        float d = float.Parse(Console.ReadLine());

        Console.Write("Enter a number: ");
        float e = float.Parse(Console.ReadLine());

        float biggest = a;

        if (b > biggest)
        {
            biggest = b;
        }

        if (c > biggest)
        {
            biggest = c;
        }

        if (d > biggest)
        {
            biggest = d;
        }

        if (e > biggest)
        {
            biggest = e;
        }

        Console.WriteLine("The biggest number is: {0:0.##}", biggest);
    }
}