//Write a program that shows the sign (+ or -) of the product of three real numbers without calculating it. Use a sequence of if statements.

using System;
using System.Globalization;
using System.Threading;

class SignOfProduct
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Enter a number: ");
        float first = float.Parse(Console.ReadLine());

        Console.Write("Enter another number: ");
        float second = float.Parse(Console.ReadLine());

        Console.Write("Enter one more number: ");
        float third = float.Parse(Console.ReadLine());

        if (first == 0 || second == 0 || third == 0)
        {
            Console.WriteLine("The product equals 0");
            return;
        }

        bool isPositive = true;

        if (first < 0)
        {
            if (second < 0)
            {
                if (third < 0)
                {
                    isPositive = false;
                }
            }
            else
            {
                if (third > 0)
                {
                    isPositive = false;
                }
            }
        }
        else
        {
            if (second < 0)
            {
                if (third > 0)
                {
                    isPositive = false;
                }
            }
            else
            {
                if (third < 0)
                {
                    isPositive = false;
                }
            }
        }

        Console.WriteLine(isPositive ? "The sign of the product is \"+\"" : "The sign of the product is \"-\"");
    }
}