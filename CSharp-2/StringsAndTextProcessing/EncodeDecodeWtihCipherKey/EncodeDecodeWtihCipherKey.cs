//Write a program that encodes and decodes a string using given encryption key (cipher). The key consists of a sequence of characters. The encoding/decoding is done by performing XOR (exclusive or)
//operation over the first letter of the string with the first of the key, the second – with the second, etc. When the last key character is reached, the next is the first.

using System;
using System.Text;

class EncodeDecodeWtihCipherKey
{
    const string cipher = "asdf";

    static string Encode(string str)
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0, j = 0; i < str.Length; i++, j++)
        {
            result.Append((char)(str[i] ^ cipher[j]));

            if (j == cipher.Length - 1)
            {
                j = 0;
            }
        }

        return result.ToString();
    }

    static string Decode(string encodedStr)
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0, j = 0; i < encodedStr.Length; i++, j++)
        {
            result.Append((char)(encodedStr[i] ^ cipher[j]));

            if (j == cipher.Length - 1)
            {
                j = 0;
            }
        }

        return result.ToString();
    }

    static void Main()
    {
        string str = "Hello world!";
        string encodedStr = Encode(str);
        string decodedStr = Decode(encodedStr);

        Console.WriteLine(str);
        Console.WriteLine(encodedStr);
        Console.WriteLine(decodedStr);
    }
}