//* Write a program that shows the internal binary representation of given 32-bit signed floating-point number in IEEE 754 format (the C# type float).
//Example: -27,25  sign = 1, exponent = 10000011, mantissa = 10110100000000000000000.

using System;
using System.Text;

class FloatBinaryRepresentation
{
    static string GetBytesSingle(float number)      //Returns the hex representation of float number
    {
        byte[] byteArray = BitConverter.GetBytes(number);
        Array.Reverse(byteArray);
        string result = BitConverter.ToString(byteArray);
        return result;
    }

    static void Main()
    {
        float floatNumber = -27.25f;

        string hexCode = GetBytesSingle(floatNumber);
        StringBuilder binary = new StringBuilder();

        //Hex to binary
        for (int i = 0; i < hexCode.Length; i++)
        {
            switch (hexCode[i])
            {
                case '0':
                {
                    binary.Append("0000");
                    break;
                }
                case '1':
                {
                    binary.Append("0001");
                    break;
                }
                case '2':
                {
                    binary.Append("0010");
                    break;
                }
                case '3':
                {
                    binary.Append("0011");
                    break;
                }
                case '4':
                {
                    binary.Append("0100");
                    break;
                }
                case '5':
                {
                    binary.Append("0101");
                    break;
                }
                case '6':
                {
                    binary.Append("0110");
                    break;
                }
                case '7':
                {
                    binary.Append("0111");
                    break;
                }
                case '8':
                {
                    binary.Append("1000");
                    break;
                }
                case '9':
                {
                    binary.Append("1001");
                    break;
                }
                case 'A':
                {
                    binary.Append("1010");
                    break;
                }
                case 'a':
                {
                    binary.Append("1010");
                    break;
                }
                case 'B':
                {
                    binary.Append("1011");
                    break;
                }
                case 'b':
                {
                    binary.Append("1011");
                    break;
                }
                case 'C':
                {
                    binary.Append("1100");
                    break;
                }
                case 'c':
                {
                    binary.Append("1100");
                    break;
                }
                case 'D':
                {
                    binary.Append("1101");
                    break;
                }
                case 'd':
                {
                    binary.Append("1101");
                    break;
                }
                case 'E':
                {
                    binary.Append("1110");
                    break;
                }
                case 'e':
                {
                    binary.Append("1110");
                    break;
                }
                case 'F':
                {
                    binary.Append("1111");
                    break;
                }
                case 'f':
                {
                    binary.Append("1111");
                    break;
                }
            }
        }

        //Insert empty spaces to separate the sign from the exponent and from the mantissa for more readability
        binary.Insert(1, " ");
        binary.Insert(10, " ");

        Console.WriteLine("Binary: {0}", binary);
    }
}