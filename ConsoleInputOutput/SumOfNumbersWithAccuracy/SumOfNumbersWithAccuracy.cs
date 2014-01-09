//Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...

using System;

class SumOfNumbersWithAccuracy
{
    static void Main()
    {
        decimal sum = 1m;

        for (int i = 2; i <= 1000; i++)
        {
            if (i % 2 == 0)
            {
                sum += (1m / i);
            }
            else
            {
                sum -= (1m / i);
            }
        }

        Console.WriteLine("The sum is {0}", sum);
    }
}