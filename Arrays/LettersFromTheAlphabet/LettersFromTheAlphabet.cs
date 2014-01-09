//Write a program that creates an array containing all letters from the alphabet (A-Z). Read a word from the console and print the index of each of its letters in the array.

using System;

class LettersFromTheAlphabet
{
    static void Main()
    {
        char[] letters = new char[52];

        for (int i = 0; i < letters.Length / 2; i++)                                    //Filling up the array letters with small letters
        {
            letters[i] = (char)(97 + i);
        }

        for (int i = letters.Length / 2, k = 0; i < letters.Length; i++, k++)           //Filling up the array letters with capital letters
        {
            letters[i] = (char)(65 + k);
        }

        Console.Write("Enter a word: ");

        string input = Console.ReadLine();
        char[] word = input.ToCharArray();

        for (int i = 0; i < word.Length; i++)
        {
            for (int j = 0; j < letters.Length; j++)
            {
                if (word[i] == letters[j])
                {
                    Console.WriteLine("Letter {0} has index: {1}.", word[i], j + 1);
                    break;
                }
            }
        }
    }
}