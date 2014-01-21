//Write a program that extracts from a given text all sentences containing given word. Consider that the sentences are separated by "." and the words – by non-letter symbols.

using System;

class SentenceWithWordExtract
{
    static void Main()
    {
        string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string pattern = " in ";

        string[] stringSeparator = { ". ", "." };

        string[] sentences = text.Split(stringSeparator, StringSplitOptions.RemoveEmptyEntries);

        foreach (var sentence in sentences)
        {
            if (sentence.Contains(pattern))
            {
                Console.WriteLine(sentence + ".");
            }
        }
    }
}