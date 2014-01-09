//Write a program that safely compares floating-point numbers with precision of 0.000001. Examples:(5.3 ; 6.01)  false;  (5.00000001 ; 5.00000003)  true

using System;
using System.Globalization;
using System.Threading;

class FloatingPointComparison
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Enter a number: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Enter a number: ");
        double b = double.Parse(Console.ReadLine());

        bool areEqual = Math.Abs(a - b) < 0.000001;

        if (areEqual)
        {
            Console.WriteLine("The numbers are equal with precision of 0.000001.");
        }
        else
        {
            Console.WriteLine("The numbers are not equal with precision of 0.000001.");
        }
    }
}