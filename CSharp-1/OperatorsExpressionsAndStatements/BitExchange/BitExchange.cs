//Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.

using System;

class BitExchange
{
    static void Main()
    {
        Console.Write("Enter a positive integer number: ");
        uint userInput = uint.Parse(Console.ReadLine());
        Console.WriteLine(Convert.ToString(userInput, 2).PadLeft(32, '0'));

        uint bit3 = ((userInput & (1 << 3)) == 0) ? 0u : 1u;
        uint bit4 = ((userInput & (1 << 4)) == 0) ? 0u : 1u;
        uint bit5 = ((userInput & (1 << 5)) == 0) ? 0u : 1u;
        uint bit24 = ((userInput & (1 << 24)) == 0) ? 0u : 1u;
        uint bit25 = ((userInput & (1 << 25)) == 0) ? 0u : 1u;
        uint bit26 = ((userInput & (1 << 26)) == 0) ? 0u : 1u;

        if (bit3 != bit24)
        {
            userInput = userInput ^ (1 << 3) ^ (1 << 24);
        }
        if (bit4 != bit25)
        {
            userInput = userInput ^ (1 << 4) ^ (1 << 25);
        }
        if (bit5 != bit26)
        {
            userInput = userInput ^ (1 << 5) ^ (1 << 26);
        }

        Console.WriteLine(userInput);
        Console.WriteLine(Convert.ToString(userInput, 2).PadLeft(32, '0'));
    }
}