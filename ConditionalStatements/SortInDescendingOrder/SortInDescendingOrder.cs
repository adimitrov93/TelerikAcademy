//Sort 3 real values in descending order using nested if statements.

using System;
using System.Globalization;
using System.Threading;

class SortInDescendingOrder
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Enter a number: ");
        float first = float.Parse(Console.ReadLine());

        Console.Write("Enter a number: ");
        float second = float.Parse(Console.ReadLine());

        Console.Write("Enter a number: ");
        float third = float.Parse(Console.ReadLine());

        float top, medium, bottom;

        if (first > second)
        {
            if (first > third)
            {
                top = first;

                if (second > third)
                {
                    medium = second;
                    bottom = third;
                }
                else
                {
                    medium = third;
                    bottom = second;
                }
            }
            else
            {
                top = third;
                medium = first;
                bottom = second;
            }
        }
        else
        {
            if (second > third)
            {
                top = second;

                if (first > third)
                {
                    medium = first;
                    bottom = third;
                }
                else
                {
                    medium = third;
                    bottom = first;
                }
            }
            else
            {
                top = third;
                medium = second;
                bottom = first;
            }
        }

        Console.WriteLine(top);
        Console.WriteLine(medium);
        Console.WriteLine(bottom);
    }
}