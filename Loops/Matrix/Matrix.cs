//Write a program that reads from the console a positive integer number N (N < 20) and outputs a matrix.

using System;

class Matrix
{
    static void Main()
    {
        Console.Write("Enter a positive integer number N (n < 20): ");
        int n = int.Parse(Console.ReadLine());

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write("{0, 3}", row + col + 1);
            }

            Console.WriteLine();
        }
    }
}