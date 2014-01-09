//Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).

/*
 * QuickSort is basically this:
 * 1. Choosing a pivot.
 * 2. Moving all smaller elements than the pivot to the left of the pivot.
 * 3. Moving all bigger elements than the pivot to the right of the pivot.
 * 4. Repeating this 3 steps for the subarrays left and right from the pivot.
*/
using System;

class QuickSort
{
    static void Main()
    {
        int[] array = { 8, 6, 3, 2, 5, 1, 7, 9, 4 };

        QuickSortMethod(array, 0, array.Length - 1);

        foreach (var item in array)
        {
            Console.WriteLine(item);
        }
    }

    public static void QuickSortMethod(int[] array, int start, int end)
    {
        if (start < end)
        {
            int pIndex = Partition(array, start, end);

            QuickSortMethod(array, start, pIndex - 1);
            QuickSortMethod(array, pIndex + 1, end);
        }
    }

    private static int Partition(int[] array, int start, int end)
    {
        int pivot = array[end];
        int pIndex = start;

        for (int i = start; i < end; i++)
        {
            if (array[i] < pivot)
            {
                swap(array, i, pIndex);

                pIndex++;
            }
        }

        swap(array, pIndex, end);

        return pIndex;
    }

    private static void swap(int[] array, int first, int second)            //Change the positions of 2 elements
    {
        int temp = array[first];
        array[first] = array[second];
        array[second] = temp;
    }
}