//* Write a program that sorts an array of integers using the merge sort algorithm (find it in Wikipedia).

//Merge sort is basically partitioning one array until it contains only 1 element and then merging it into one sorted array.

using System;

class MergeSort
{
    static void Main()
    {
        int[] array = { 5, 3, 6, 4, 2, 1 };

        MergeSortMethod(array);

        foreach (var item in array)
        {
            Console.WriteLine(item);
        }
    }

    public static void MergeSortMethod(int[] array)
    {
        if (array.Length == 1)          //If the array has only 1 element this method returns
        {
            return;
        }

        //Creating two separate arrays for the left and the right subarray
        int[] leftArray = new int[array.Length / 2];
        int[] rightArray = new int[array.Length - leftArray.Length];


        //Filling up this two subarrays
        for (int i = 0; i < leftArray.Length; i++)
        {
            leftArray[i] = array[i];
        }

        for (int i = leftArray.Length; i < array.Length; i++)
        {
            rightArray[i - leftArray.Length] = array[i];
        }

        MergeSortMethod(leftArray);
        MergeSortMethod(rightArray);

        Merge(array, leftArray, rightArray);
    }

    private static void Merge(int[] array, int[] leftArray, int[] rightArray)
    {
        int leftIndex = 0;
        int rightIndex = 0;
        int index = 0;

        while (leftIndex < leftArray.Length || rightIndex < rightArray.Length)
        {
            if (leftIndex < leftArray.Length && rightIndex < rightArray.Length)
            {
                if (leftArray[leftIndex] < rightArray[rightIndex])
                {
                    array[index++] = leftArray[leftIndex++];
                }
                else
                {
                    array[index++] = rightArray[rightIndex++];
                }
            }
            else if (leftIndex < leftArray.Length)
            {
                array[index++] = leftArray[leftIndex++];
            }
            else if (rightIndex < rightArray.Length)
            {
                array[index++] = rightArray[rightIndex++];
            }
        }
    }
}