//Write a program to convert hexadecimal numbers to their decimal representation.

using System;

class HexadecimalToDecimal
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

    static int[] ToIntArray(string hexadecimalNumber)
    {
        int[] hexadecimalArray = new int[hexadecimalNumber.Length];

        for (int i = 0; i < hexadecimalNumber.Length; i++)
        {
            if (hexadecimalNumber[i] >= 48 && hexadecimalNumber[i] <= 57)
            {
                hexadecimalArray[i] = hexadecimalNumber[i] - '0';
            }
            else if (hexadecimalNumber[i] == 'A')
            {
                hexadecimalArray[i] = 10;
            }
            else if (hexadecimalNumber[i] == 'B')
            {
                hexadecimalArray[i] = 11; ;
            }
            else if (hexadecimalNumber[i] == 'C')
            {
                hexadecimalArray[i] = 12;
            }
            else if (hexadecimalNumber[i] == 'D')
            {
                hexadecimalArray[i] = 13;
            }
            else if (hexadecimalNumber[i] == 'E')
            {
                hexadecimalArray[i] = 14;
            }
            else if (hexadecimalNumber[i] == 'F')
            {
                hexadecimalArray[i] = 15;
            }
            else
            {
                Console.WriteLine("Invalid number!");
                Environment.Exit(-1);
            }
        }

        return hexadecimalArray;
    }

    static void Main()
    {
        string hexadecimalNumber = "668DC";

        int[] hexadecimalArray = ToIntArray(hexadecimalNumber);

        int decimalNumber = 0;

        for (int i = hexadecimalArray.Length - 1, index = 0; i >= 0; i--, index++)
        {
            decimalNumber += hexadecimalArray[i] * Power(16, index);
        }

        Console.WriteLine("Hexadecimal: {0}", hexadecimalNumber);
        Console.WriteLine("Decimal: {0}", decimalNumber);
    }
}