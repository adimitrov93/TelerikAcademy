//Write a program that finds the sequence of maximal sum in given array. Example:
//	{2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}
//	Can you do it with only one loop (with single scan through the elements of the array)?

using System;

class SubarrayMaxSum
{
    static void Main()
    {
        int[] array = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };

        int startIndex = 0;
        int tempStartIndex = 0;
        int endIndex = 0;
        int currentSum = array[0];
        int maxSum = array[0];

        /*
         * Kadane's algorithm
         * Find start and end index of the sequence of maximal sum in an array.
         * Sum elements one by one until you reach an element, larger than the current sum. That's your start index.
         * Sum elements one by one until their sum is not maximal. That's your end index.
         */

        for (int i = 1; i < array.Length; i++)
        {
            currentSum += array[i];

            if (array[i] > currentSum)
            {
                currentSum = array[i];
                tempStartIndex = i;
            }

            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                startIndex = tempStartIndex;
                endIndex = i;
            }
        }

        Console.Write("{");

        for (int i = startIndex; i <= endIndex; i++)
        {
            if (i == endIndex)
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