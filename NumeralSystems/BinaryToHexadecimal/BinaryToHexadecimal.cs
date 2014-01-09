//Write a program to convert binary numbers to hexadecimal numbers (directly).

using System;
using System.Text;

class BinaryToHexadecimal
{
    static char BinToHex(string binaryNumber)
    {
        char result = (char)0;

        if (binaryNumber == "0000")
        {
            result = '0';
        }
        else if (binaryNumber == "0001")
        {
            result = '1';
        }
        else if (binaryNumber == "0010")
        {
            result = '2';
        }
        else if (binaryNumber == "0011")
        {
            result = '3';
        }
        else if (binaryNumber == "0100")
        {
            result = '4';
        }
        else if (binaryNumber == "0101")
        {
            result = '5';
        }
        else if (binaryNumber == "0110")
        {
            result = '6';
        }
        else if (binaryNumber == "0111")
        {
            result = '7';
        }
        else if (binaryNumber == "1000")
        {
            result = '8';
        }
        else if (binaryNumber == "1001")
        {
            result = '9';
        }
        else if (binaryNumber == "1010")
        {
            result = 'A';
        }
        else if (binaryNumber == "1011")
        {
            result = 'B';
        }
        else if (binaryNumber == "1100")
        {
            result = 'C';
        }
        else if (binaryNumber == "1101")
        {
            result = 'D';
        }
        else if (binaryNumber == "1110")
        {
            result = 'E';
        }
        else if (binaryNumber == "1111")
        {
            result = 'F';
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid number!");
            Environment.Exit(-1);
        }

        return result;
    }

    static string AddLeadZeros(string binaryNumber)
    {
        int leadZeros = 4 - binaryNumber.Length % 4;

        return new string('0', leadZeros) + binaryNumber;
    }

    static void Main()
    {
        string binaryNumber = "1001110101001";
        StringBuilder hexadecimalNumber = new StringBuilder();

        binaryNumber = AddLeadZeros(binaryNumber);

        for (int i = 0; i < binaryNumber.Length; i+=4)
        {
            hexadecimalNumber.Append(BinToHex(binaryNumber.Substring(i, 4)));
        }

        Console.WriteLine(hexadecimalNumber);
    }
}