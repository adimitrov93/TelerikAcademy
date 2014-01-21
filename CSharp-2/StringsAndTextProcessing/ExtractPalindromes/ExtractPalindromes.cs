//Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

using System;

class ExtractPalindromes
{
    static bool IsSymmetric(string str)
    {
        bool IsSymmetric = true;

        for (int i = 0; i < str.Length / 2; i++)
        {
            if (!str[i].Equals(str[str.Length - i - 1]))
            {
                IsSymmetric = false;
                break;
            }
        }

        return IsSymmetric;
    }

    static string RemoveNonChars(string str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            if (!(Char.IsLetterOrDigit(str[i]) || Char.IsWhiteSpace(str[i])))
            {
                str = str.Remove(i, 1);
                i--;
            }
        }

        return str;
    }

    static void Main()
    {
        string text = "Abba is group full of lamal. They love to do exe.";
        text = text.ToLower();
        text = RemoveNonChars(text);
        string[] words = text.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            if (IsSymmetric(words[i]))
            {
                Console.WriteLine(words[i]);
            }
        }
    }
}