//Write an expression that extracts from a given integer i the value of a given bit number b. Example: i=5; b=2  value=1.

using System;

class BitExtractor
{
    static void Main()
    {
        Console.Write("Enter an integer number: ");
        int i = int.Parse(Console.ReadLine());
        Console.Write("Position: ");
        int b = int.Parse(Console.ReadLine());

        int mask = 1;
        mask <<= b;

        i &= mask;
        i >>= b;

        Console.WriteLine("Value = {0}", i);
    }
}