//Write a program to convert hexadecimal numbers to binary numbers (directly).

using System;
using System.Text;

class HexadecimalToBinary
{
    static string HexToBin(char hexDigit)
    {
        string result = null;

        if (hexDigit == '0')
        {
            result = "0000";
        }
        else if (hexDigit == '1')
        {
            result = "0001";
        }
        else if (hexDigit == '2')
        {
            result = "0010";
        }
        else if (hexDigit == '3')
        {
            result = "0011";
        }
        else if (hexDigit == '4')
        {
            result = "0100";
        }
        else if (hexDigit == '5')
        {
            result = "0101";
        }
        else if (hexDigit == '6')
        {
            result = "0110";
        }
        else if (hexDigit == '7')
        {
            result = "0111";
        }
        else if (hexDigit == '8')
        {
            result = "1000";
        }
        else if (hexDigit == '9')
        {
            result = "1001";
        }
        else if (hexDigit == 'A')
        {
            result = "1010";
        }
        else if (hexDigit == 'B')
        {
            result = "1011";
        }
        else if (hexDigit == 'C')
        {
            result = "1100";
        }
        else if (hexDigit == 'D')
        {
            result = "1101";
        }
        else if (hexDigit == 'E')
        {
            result = "1110";
        }
        else if (hexDigit == 'F')
        {
            result = "1111";
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid number!");
            Environment.Exit(-1);
        }

        return result;
    }

    static void RemoveLeadZeros(ref StringBuilder binaryNumber)
    {
        for (int i = 0; i < binaryNumber.Length; i++)
        {
            if (binaryNumber[i] != '0')
            {
                binaryNumber.Remove(0, i);
                break;
            }
        }
    }

    static void Main()
    {
        string hexadecimalNumber = "617DC";
        StringBuilder binaryNumber = new StringBuilder();

        for (int i = 0; i < hexadecimalNumber.Length; i++)
        {
            binaryNumber.Append(HexToBin(hexadecimalNumber[i]));
        }

        RemoveLeadZeros(ref binaryNumber);

        Console.WriteLine(binaryNumber);
    }
}