//Write a method that return the maximal element in a portion of array of integers starting at given index. Using it write another method that sorts an array in ascending / descending order.

using System;

class MaxElementInSubarray
{
    static int MaxInSubarray(int[] array, int startIndex)
    {
        int max = int.MinValue;
        int maxIndex = 0;

        for (int i = startIndex; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
                maxIndex = i;
            }
        }

        return maxIndex;
    }

    static void Swap(int[] array, int first, int second)
    {
        int temp = array[first];
        array[first] = array[second];
        array[second] = temp;
    }

    static void SortInDescendingOrder(int[] array)                  //With the method MaxInSubarray implemented in that way, we can't make method for sorting in ascending order.
    {
        int maxIndex = 0;

        for (int i = 0; i < array.Length; i++)
        {
            maxIndex = MaxInSubarray(array, i);

            Swap(array, i, maxIndex);
        }
    }

    static void Main()
    {
        int[] arrayOfNumbers = { 5, 1, 2, 15, 4, 5, 1, 2, 9 };

        SortInDescendingOrder(arrayOfNumbers);

        Console.WriteLine("Sorted: {0}", String.Join(", ", arrayOfNumbers));
    }
}