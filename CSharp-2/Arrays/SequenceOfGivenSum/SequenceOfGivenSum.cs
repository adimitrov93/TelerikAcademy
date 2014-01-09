//Write a program that finds in given array of integers a sequence of given sum S (if present). Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}

using System;

class SequenceOfGivenSum
{
    static void Main()
    {
        int[] array = { 4, 3, 1, 4, 2, 5, 8 };

        int s = 8;
        int currentSum = 0;
        int startIndex = 0;
        int lastIndex = 0;

        bool sumFound = false;

        for (int i = 0; i < array.Length && !sumFound; i++)
        {
            startIndex = i;
            currentSum = 0;

            for (int j = i; j < array.Length && !sumFound; j++)
            {
                currentSum += array[j];

                if (currentSum == s)
                {
                    lastIndex = j;
                    sumFound = true;
                }
                else if (currentSum > s)
                {
                    break;
                }
            }
        }

        Console.Write("{");

        for (int i = startIndex; i <= lastIndex; i++)
        {
            if (i == lastIndex)
            {
                Console.Write("{0}", array[i]);
            }
            else
            {
                Console.Write("{0}, ", array[i]);
            }
        }

        Console.WriteLine("}");
    }
}