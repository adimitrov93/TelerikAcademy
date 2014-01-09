//Write a method that returns the index of the first element in array that is bigger than its neighbors, or -1, if there’s no such element. Use the method from the previous exercise.

using System;

class TheFirstBiggerThanNeighbors
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

    static int FirstBiggerThanNeighbors(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (IsBigger(array, i))
            {
                return i;
            }
        }

        return -1;
    }

    static void Main()
    {
        int[] arrayOfNumbers = { 2, 3, 1, 3, 3, 3, 5, 3 };

        int result = FirstBiggerThanNeighbors(arrayOfNumbers);

        if (result != -1)
        {
            Console.WriteLine("The index of first number bigger than its neighbors is {0}.", result);            
        }
        else
        {
            Console.WriteLine("There is no number in this array bigger than its neighbors.");
        }
    }
}