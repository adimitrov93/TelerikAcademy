//Write a program that reads a number N and calculates the sum of the first N members of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
//Each member of the Fibonacci sequence (except the first two) is a sum of the previous two members.

using System;
using System.Numerics;

class FibonacciSequence
{
    static void Main()
    {
        Console.WriteLine("The program prints the first N numbers of the Fibonacci Sequence.");
        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine());

        BigInteger first = 0, second = 1;

        for (int i = 0; i < n; i += 2, first += second, second += first)
        {
            Console.WriteLine("{0}: {1}", i + 1, first);
            Console.WriteLine("{0}: {1}", i + 2, second);
        }
    }
}