//Write a boolean expression that returns if the bit at position p (counting from 0) in a given integer number v has value of 1. Example: v=5; p=1  false.

using System;

class BitChecker
{
    static void Main()
    {
        Console.Write("Enter an integer number: ");
        int v = int.Parse(Console.ReadLine());
        Console.Write("Position: ");
        int p = int.Parse(Console.ReadLine());

        int mask = 1;
        mask <<= p;

        v &= mask;

        Console.WriteLine(v != 0 ? "True" : "False");
    }
}