//A dictionary is stored as a sequence of text lines containing words and their explanations. Write a program that enters a word and translates it by using the dictionary. Sample dictionary:

using System;
using System.Collections.Generic;

class Dictionary
{
    static void Main()
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();

        dictionary.Add(".NET", "platform for applications from Microsoft");
        dictionary.Add("CLR", "managed execution environment for .NET");
        dictionary.Add("namespace", "hierarchical organization of classes");

        Console.Write("Enter a word to translate: ");
        string wordToTranslate = Console.ReadLine();

        foreach (var word in dictionary)
        {
            if (word.Key.Equals(wordToTranslate, StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("{0} - {1}", word.Key, word.Value);
            }
        }
    }
}