//Write a program to convert decimal numbers to their binary representation.

using System;
using System.Collections.Generic;

class DecimalToBinary
{
    static void Main()
    {
        int decimalNumber = 514;
        Console.WriteLine("Decimal: {0}", decimalNumber);

        int remainder = 0;
        List<int> binaryNumber = new List<int>();

        while (decimalNumber > 1)
        {
            remainder = decimalNumber % 2;
            decimalNumber /= 2;

            binaryNumber.Add(remainder);
        }

        binaryNumber.Add(1);

        Console.Write("Binary: ");

        for (int i = binaryNumber.Count - 1; i >= 0; i--)
        {
            Console.Write(binaryNumber[i]);
        }

        Console.WriteLine();
    }
}