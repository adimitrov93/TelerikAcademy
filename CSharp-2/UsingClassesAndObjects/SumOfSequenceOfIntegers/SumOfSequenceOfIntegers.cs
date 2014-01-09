//You are given a sequence of positive integer values written into a string, separated by spaces. Write a function that reads these values from given string and calculates their sum. Example:
//		string = "43 68 9 23 318"  result = 461

using System;
using System.Collections.Generic;

class SumOfSequenceOfIntegers
{
    static int[] SplitASequenceOfNumbers(string sequence)       //Returns array of ints containing the numbers from the sequence
    {
        List<int> numbersFromSequence = new List<int>();
        int number = 0;

        for (int i = 0; i < sequence.Length; i++)
        {
            if (sequence[i] != ' ')
            {
                number *= 10;
                number += sequence[i] - '0';
            }
            else
            {
                numbersFromSequence.Add(number);
                number = 0;
            }
        }

        if (number != 0)
        {
            numbersFromSequence.Add(number);
        }

        return numbersFromSequence.ToArray();
    }

    static int SumOfIntegers(int[] numbers)     //Returns the sum of an array of integers
    {
        int sum = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        return sum;
    }


    static void Main()
    {
        string sequenceOfIntegers = "50 21 16 201 1014";

        int[] numbersFromSequence = SplitASequenceOfNumbers(sequenceOfIntegers);

        int sum = SumOfIntegers(numbersFromSequence);

        Console.WriteLine("The sum is {0}.", sum);
    }
}