//Sorting an array means to arrange its elements in increasing order. Write a program to sort an array. Use the "selection sort" algorithm: Find the smallest element, move it at the first position,
//find the smallest from the rest, move it at the second position, etc.

using System;

class SortingArray
{
    static void Main()
    {
        int[] array = { 5, 4, 6, 1, 9, -5, 41, 34 };

        int smallestElem = 0, position = 0;

        for (int i = 0; i < array.Length; i++)
        {
            smallestElem = array[i];
            position = i;

            for (int j = i; j < array.Length; j++)              //Finding the smallest element
            {
                if (array[j] < smallestElem)
                {
                    smallestElem = array[j];
                    position = j;
                }
            }

            if (smallestElem < array[i])
            {
                array[position] = array[i];
                array[i] = smallestElem;
            }
        }

        foreach (var item in array)
        {
            Console.WriteLine(item);
        }
    }
}