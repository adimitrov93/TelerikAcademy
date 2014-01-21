//Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.

using System;
using System.Collections.Generic;

class SortListOfWords
{
    static void Main()
    {
        Console.Write("Enter list of words separated by space: ");
        string input = Console.ReadLine();
        string[] inputWords = input.Split(' ');

        SortedSet<string> words = new SortedSet<string>();

        foreach (var word in inputWords)
        {
            words.Add(word);
        }

        foreach (var word in words)
        {
            Console.WriteLine(word);
        }
    }
}