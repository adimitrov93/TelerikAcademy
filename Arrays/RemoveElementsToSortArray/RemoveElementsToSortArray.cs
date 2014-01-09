//* Write a program that reads an array of integers and removes from it a minimal number of elements in such way that the remaining array is sorted in increasing order.
//Print the remaining sorted array. Example:
//	{6, 1, 4, 3, 0, 3, 6, 4, 5}  {1, 3, 3, 4, 5}

//This program uses the algorithm for finding subsets from the previous tasks for subset sums.

using System;
using System.Collections.Generic;

class RemoveElementsToSortArray
{
    static List<int> biggestArray = new List<int>();                //This list keeps the biggest sorted array found.

    static bool isSorted(List<int> subarray)                        //Check if given List is sorted
    {
        bool isSorted = true;

        for (int i = 1; i < subarray.Count; i++)
        {
            if (subarray[i - 1] > subarray[i])
            {
                isSorted = false;
                break;
            }
        }

        return isSorted;
    }

    static void subarray(int[] array, int combinations)
    {
        List<int> subarray = new List<int>();

        for (int i = 1; i < combinations; i++)
        {
            subarray.Clear();

            for (int j = array.Length - 1; j >= 0; j--)
            {
                if (((i >> j) & 1) != 0)
                {
                    subarray.Add(array[array.Length - j - 1]);
                }
            }

            if (isSorted(subarray) && (subarray.Count > biggestArray.Count))
            {
                biggestArray.Clear();

                for (int j = 0; j < subarray.Count; j++)
                {
                    biggestArray.Add(subarray[j]);
                }
            }
        }
    }

    static void Main()
    {
        int[] array = { 6, 1, 4, 3, 0, 3, 6, 4, 5 };
        int combinations = (int)Math.Pow(2, array.Length) - 1;

        subarray(array, combinations);

        foreach (var item in biggestArray)
        {
            Console.Write("{0} ", item);
        }

        Console.WriteLine();
    }
}