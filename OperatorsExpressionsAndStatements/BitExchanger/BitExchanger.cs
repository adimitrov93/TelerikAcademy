//*Write a program that exchanges bits {p, p+1, …, p+k-1) with bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.

using System;

class BitExchanger
{
    static void Main()
    {
        Console.Write("Enter a positive integer number: ");
        uint userInput = uint.Parse(Console.ReadLine());
        Console.WriteLine(Convert.ToString(userInput, 2).PadLeft(32, '0'));

        Console.Write("Enter p: ");
        int p = int.Parse(Console.ReadLine());
        Console.Write("Enter q: ");
        int q = int.Parse(Console.ReadLine());
        Console.Write("Enter k: ");
        int k = int.Parse(Console.ReadLine());

        int pBit, qBit;

        for (int i = 0; i <= (k - 1); i++)
        {
            pBit = ((userInput & (1 << p)) == 0) ? 0 : 1;
            qBit = ((userInput & (1 << q)) == 0) ? 0 : 1;

            if (pBit != qBit)
            {
                userInput = userInput ^ (uint)(1 << p) ^ (uint)(1 << q);
            }
            p++;
            q++;
        }

        Console.WriteLine(userInput);
        Console.WriteLine(Convert.ToString(userInput, 2).PadLeft(32, '0'));
    }
}