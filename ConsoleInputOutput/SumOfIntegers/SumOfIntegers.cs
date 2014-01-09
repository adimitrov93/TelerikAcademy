//Write a program that reads 3 integer numbers from the console and prints their sum.

using System;

class SumOfIntegers
{
    static void Main()
    {
        Console.Write("Enter an integer number: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter an integer number: ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Enter an integer number: ");
        int c = int.Parse(Console.ReadLine());

        Console.WriteLine("{0} + {1} + {2} = {3}", a, b, c, a + b + c);
    }
}