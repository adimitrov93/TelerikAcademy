//Write a program that reads a string from the console and prints all different letters in the string along with information how many times each letter is found. 

using System;
using System.Collections.Generic;

class LetterCounter
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string str = Console.ReadLine();

        Dictionary<char, int> letters = new Dictionary<char, int>();

        for (int i = 0; i < str.Length; i++)
        {
            if (Char.IsLetter(str[i]))
            {
                if (letters.ContainsKey(str[i]))
                {
                    letters[str[i]]++;
                }
                else
                {
                    letters.Add(str[i], 1);
                }
            }
        }

        foreach (var letter in letters)
        {
            if (letter.Value > 1)
            {
                Console.WriteLine("{0} - {1} times", letter.Key, letter.Value);                
            }
            else
            {
                Console.WriteLine("{0} - {1} time", letter.Key, letter.Value);
            }
        }
    }
}