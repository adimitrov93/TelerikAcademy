//Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings. Sample input:

using System;
using System.Text;

class StringToUnicodeCharacters
{
    static void Main()
    {
        string str = "Hi!";
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < str.Length; i++)
        {
            result.Append(String.Format("\\u{0:X4}", (int)str[i]));
        }

        Console.WriteLine(result);
    }
}