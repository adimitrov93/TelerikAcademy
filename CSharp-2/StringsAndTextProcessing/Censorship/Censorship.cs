//We are given a string containing a list of forbidden words and a text containing some of these words. Write a program that replaces the forbidden words with asterisks. Example:

using System;

class Censorship
{
    static void Main()
    {
        string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        string[] forbiddenWords =
        {
            "PHP",
            "CLR",
            "Microsoft"
        };

        foreach (var word in forbiddenWords)
        {
            if (text.Contains(word))
            {
                text = text.Replace(word, new string('*', word.Length));
            }
        }

        Console.WriteLine(text);
    }
}