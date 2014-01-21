//Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one. Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa".

using System;
using System.Text;

class RemoveConsecutiveIdenticalLetters
{
    static string RemoveConsecutiveIdenticals(string str)
    {
        StringBuilder result = new StringBuilder();
        result.Append(str[0]);

        for (int i = 1; i < str.Length; i++)
        {
            if (!str[i].Equals(result[result.Length - 1]))
            {
                result.Append(str[i]);
            }
        }

        return result.ToString();
    }

    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        string result = RemoveConsecutiveIdenticals(input);

        Console.WriteLine(result);
    }
}