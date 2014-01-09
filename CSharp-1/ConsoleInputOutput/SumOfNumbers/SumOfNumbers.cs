//Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum. 

using System;
using System.Globalization;
using System.Threading;

class SumOfNumbers
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Enter a positive integer number: ");
        int count = int.Parse(Console.ReadLine());

        float sum = 0;

        for (int i = 0; i < count; i++)
        {
            Console.Write("Enter {0} more numbers: ", count - i);
            sum += float.Parse(Console.ReadLine());
        }

        Console.WriteLine("The sum of the numbers is {0:0.##}", sum);
    }
}