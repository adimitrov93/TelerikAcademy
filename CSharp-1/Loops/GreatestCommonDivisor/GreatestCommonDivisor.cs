//Write a program that calculates the greatest common divisor (GCD) of given two numbers. Use the Euclidean algorithm (find it in Internet).

using System;

class GreatestCommonDivisor
{
    static void Main()
    {
        Console.WriteLine("The program calculates the greatest common divisor of x and y.");
        Console.Write("Enter x: ");
        int x = int.Parse(Console.ReadLine());
        Console.Write("Enter y: ");
        int y = int.Parse(Console.ReadLine());

        if (x == 0)
        {
            Console.WriteLine("GCD = {0}", y);
            return;
        }
        else if (y == 0)
        {
            Console.WriteLine("GCD = {0}", x);
            return;
        }

        if (x < y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        int divident = x, divisor = y, remainder;

        while (true)
        {
            remainder = divident % divisor;

            if (remainder == 0)
            {
                Console.WriteLine("GCD = {0}", divisor);
                return;
            }

            divident = divisor;
            divisor = remainder;
        }
    }
}