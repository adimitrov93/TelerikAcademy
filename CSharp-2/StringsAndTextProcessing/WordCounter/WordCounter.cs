//Write a program that reads a string from the console and lists all different words in the string along with information how many times each word is found.

using System;
using System.Collections.Generic;

class WordCounter
{
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
        Console.Write("Enter a string: ");
        string str = Console.ReadLine();

        str = RemoveNonChars(str);
        str = str.ToLower();

        string[] words = str.Split(' ');
        Dictionary<string, int> counter = new Dictionary<string, int>();

        foreach (var word in words)
        {
            if (counter.ContainsKey(word))
            {
                counter[word]++;
            }
            else
            {
                counter.Add(word, 1);
            }
        }

        foreach (var word in counter)
        {
            if (word.Value > 1)
            {
                Console.WriteLine("{0} - {1} times", word.Key, word.Value);
            }
            else
            {
                Console.WriteLine("{0} - {1} time", word.Key, word.Value);
            }
        }
    }
}