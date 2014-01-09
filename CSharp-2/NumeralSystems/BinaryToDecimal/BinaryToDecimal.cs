//Write a program to convert binary numbers to their decimal representation.

using System;

class BinaryToDecimal
{
    static int Power(int baseOfNumber, int power)
    {
        int result = 1;

        for (int i = 1; i <= power; i++)
        {
            result *= baseOfNumber;
        }

        return result;
    }

    static void Main()
    {
        string binaryNumber = "1110111111001";

        int decimalNumber = 0;

        for (int i = binaryNumber.Length - 1, index = 0; i >= 0; i--, index++)
        {
            if (binaryNumber[i] == '1')
            {
                decimalNumber += Power(2, index);
            }
        }

        Console.WriteLine("Binary: {0}", binaryNumber);
        Console.WriteLine("Decimal: {0}", decimalNumber);
    }
}