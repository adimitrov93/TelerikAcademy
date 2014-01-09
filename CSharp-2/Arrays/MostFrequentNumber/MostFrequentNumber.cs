//Write a program that finds the most frequent number in an array. Example:
//	{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)

using System;

class MostFrequentNumber
{
    static void Main()
    {
        int[] array = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };                //In the example the array is filled up only with digits and this program count only digits

        int[] digits = new int[10];

        for (int i = 0; i < array.Length; i++)                                  //Count the number of digits in the array
        {                                                                       //Every index coresponds to the digits from 0 to 9
            digits[array[i]]++;
        }

        int mostFreqNumber = 0, count = 0;

        for (int i = 0; i < digits.Length; i++)                                 //Find most frequent digit
        {
            if (digits[i] > count)
            {
                mostFreqNumber = i;
                count = digits[i];
            }
        }

        Console.WriteLine("{0} ({1} times)", mostFreqNumber, count);
    }
}