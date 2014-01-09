//Write a method that counts how many times given number appears in given array. Write a test program to check if the method is working correctly.

using System;

class NumberCounter
{
    static int NumberCounterMethod(int[] array, int target)
    {
        int count = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == target)
            {
                count++;
            }
        }

        return count;
    }

    static void Main()
    {
        int[] arrayOfNumbers = { 5, 3, 6, 6, 3, 5, 5, 5, 5, 1, 2, 3, 8, 6, 0 };

        int target = 6;

        int counted = NumberCounterMethod(arrayOfNumbers, target);

        Console.WriteLine("The number {0} appears {1} times in this array.", target, counted);
    }
}