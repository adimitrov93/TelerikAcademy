//Write a program to convert decimal numbers to their hexadecimal representation.

using System;
using System.Collections.Generic;

class DecimalToHexadecimal
{
    static void Main()
    {
        int decimalNumber = 192;
        Console.WriteLine("Decimal: {0}", decimalNumber);

        List<int> hexadecimalNumber = new List<int>();
        int remainder = 0;

        while (decimalNumber > 15)
        {
            remainder = decimalNumber % 16;
            decimalNumber /= 16;

            hexadecimalNumber.Add(remainder);
        }

        hexadecimalNumber.Add(decimalNumber);

        Console.Write("Hexadecimal: ");

        for (int i = hexadecimalNumber.Count - 1; i >= 0; i--)
        {
            if (hexadecimalNumber[i] <= 9)
            {
                Console.Write(hexadecimalNumber[i]);
            }
            else if (hexadecimalNumber[i] == 10)
            {
                Console.Write("A");
            }
            else if (hexadecimalNumber[i] == 11)
            {
                Console.Write("B");
            }
            else if (hexadecimalNumber[i] == 12)
            {
                Console.Write("C");
            }
            else if (hexadecimalNumber[i] == 13)
            {
                Console.Write("D");
            }
            else if (hexadecimalNumber[i] == 14)
            {
                Console.Write("E");
            }
            else 
            {
                Console.Write("F");
            }
        }

        Console.WriteLine();
    }
}