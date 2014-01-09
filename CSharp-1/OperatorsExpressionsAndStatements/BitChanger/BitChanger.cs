//We are given integer number n, value v (v=0 or 1) and a position p. Write a sequence of operators that modifies n to hold the value v at the position p from the
//binary representation of n.
//Example:      n = 5 (00000101), p=3, v=1  13 (00001101)
//	            n = 5 (00000101), p=2, v=0  1 (00000001)

using System;

class BitChanger
{
    static void Main()
    {
        Console.Write("Enter and integer number: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter value: ");
        int v = int.Parse(Console.ReadLine());
        Console.Write("Enter position: ");
        int p = int.Parse(Console.ReadLine());

        int mask = 1;
        mask <<= p;

        if (v == 1)
        {
            n |= mask;
            Console.WriteLine(n);
        }
        else if (v == 0)
        {
            n &= (~mask);
            Console.WriteLine(n);
        }
        else
        {
            Console.WriteLine("Invalid value.");
        }
    }
}