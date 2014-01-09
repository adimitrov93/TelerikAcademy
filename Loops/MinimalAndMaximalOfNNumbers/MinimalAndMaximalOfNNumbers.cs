//Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.

using System;

class MinimalAndMaximalOfNNumbers
{
    static void Main()
    {
        Console.Write("Enter an positive integer number: ");
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];

        Console.WriteLine("Enter {0} integer numbers: ", n);

        for (int i = 0; i < n; i++)
        {
            Console.Write("{0}: ", i + 1);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int minimum = numbers[0];
        int maximum = numbers[0];

        for (int i = 1; i < n; i++)
        {
            if (numbers[i] < minimum)
            {
                minimum = numbers[i];
            }
            if (numbers[i] > maximum)
            {
                maximum = numbers[i];
            }
        }

        Console.WriteLine("Minimum = {0}", minimum);
        Console.WriteLine("Maximum = {0}", maximum);
    }
}