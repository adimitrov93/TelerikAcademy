//Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).

using System;
using System.Text;

class BinaryRepresentationOfShort
{
    static string GetBinary(short number)
    {
        int currentBit;
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < 16; i++)
        {
            currentBit = (number >> i & 1);

            result.Insert(0, currentBit);
        }

        return result.ToString();
    }

    static void Main()
    {
        short number = 12;

        Console.WriteLine(GetBinary(number));
    }
}