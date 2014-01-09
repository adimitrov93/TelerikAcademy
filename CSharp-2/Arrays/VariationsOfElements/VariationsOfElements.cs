//Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N]. Example:
//	N = 3, K = 2  {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}

//I can't explain this task so good. I recommend debuging it for understanding it.

using System;

class VariationsOfElements
{
    static int n = int.Parse(Console.ReadLine());
    static int k = int.Parse(Console.ReadLine());

    static void Variations(int[] array, int index)
    {
        if (index == array.Length)
        {
            PrintArray(array);
        }
        else
        {
            for (int i = 1; i <= n; i++)
            {
                array[index] = i;
                Variations(array, index + 1);
            }
        }
    }

    static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }

        Console.WriteLine();
    }

    static void Main()
    {
        int[] array = new int[k];
        Variations(array, 0);
    }
}