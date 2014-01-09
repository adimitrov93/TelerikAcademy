//Write a method that checks if the element at given position in given array of integers is bigger than its two neighbors (when such exist).

using System;

class IsBiggerThanNeighbors
{
    static bool IsBigger(int[] array, int position)
    {
        bool isBigger = false;

        if (position > 0 && position < array.Length - 1)
        {
            if (array[position] > array[position - 1] && array[position] > array[position + 1])
            {
                isBigger = true;
            }
        }
        else if (position == 0)
        {
            if (array[position] > array[position + 1])
            {
                isBigger = true;
            }
        }
        else if (position == array.Length - 1)
        {
            if (array[position] > array[position - 1])
            {
                isBigger = true;
            }
        }

        return isBigger;
    }

    static void Main()
    {
        int[] arrayOfNumbers = { 0, 2, 4, 3, 5, 4, 9 };

        int position = 0;

        bool isBigger = IsBigger(arrayOfNumbers, position);

        Console.WriteLine(isBigger);
    }
}