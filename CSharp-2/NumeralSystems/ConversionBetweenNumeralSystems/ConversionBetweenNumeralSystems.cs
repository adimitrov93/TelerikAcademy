//Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).

using System;
using System.Text;

class ConversionBetweenNumeralSystems
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

    static int[] ToIntArray(string number)
    {
        int[] hexadecimalArray = new int[number.Length];

        for (int i = 0; i < number.Length; i++)
        {
            if (number[i] >= 48 && number[i] <= 57)
            {
                hexadecimalArray[i] = number[i] - '0';
            }
            else if (number[i] == 'A')
            {
                hexadecimalArray[i] = 10;
            }
            else if (number[i] == 'B')
            {
                hexadecimalArray[i] = 11; ;
            }
            else if (number[i] == 'C')
            {
                hexadecimalArray[i] = 12;
            }
            else if (number[i] == 'D')
            {
                hexadecimalArray[i] = 13;
            }
            else if (number[i] == 'E')
            {
                hexadecimalArray[i] = 14;
            }
            else if (number[i] == 'F')
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

    static string OtherToDecimal(int fromBase, int[] number)
    {
        int decimalNumber = 0;

        for (int i = number.Length - 1, index = 0; i >= 0; i--, index++)
        {
            decimalNumber += number[i] * Power(fromBase, index);
        }

        return decimalNumber.ToString();
    }

    static string DecimalToOther(int toBase, int[] decimalNumber)
    {
        int remainder;
        int number = 0;
        StringBuilder wantedNumber = new StringBuilder();

        for (int i = 0; i < decimalNumber.Length; i++)
        {
            number *= 10;
            number += decimalNumber[i];
        }

        while (number > toBase - 1)
        {
            remainder = number % toBase;
            number /= toBase;

            wantedNumber.Insert(0, remainder);
        }

        wantedNumber.Insert(0, number);

        return wantedNumber.ToString();
    }

    static void Main()
    {
        int fromBase = 16;
        int toBase = 2;
        string number = "A7892";
        string wantedNumber;

        if (fromBase == 10)
        {
            wantedNumber = DecimalToOther(toBase, ToIntArray(number));
        }
        else if (toBase == 10)
        {
            wantedNumber = OtherToDecimal(fromBase, ToIntArray(number));
        }
        else
        {
            int[] numberInArray = ToIntArray(number);

            string decimalNumber = OtherToDecimal(fromBase, numberInArray);

            wantedNumber = DecimalToOther(toBase, ToIntArray(decimalNumber));
        }
        
        Console.WriteLine("{0}({1}) = {2}({3})", number, fromBase, wantedNumber, toBase);
    }
}