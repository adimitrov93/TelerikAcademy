//Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N]. Example:
//	N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}

//I can't explain this task so good. I recommend debuging it for understanding it.

using System;

class CombinationsOfDistinctElements
{
    static int n = int.Parse(Console.ReadLine());
    static int k = int.Parse(Console.ReadLine());
    static char symbol = (char)8;                               //backspace character for deleting the blank space before } in line 37

    static void Combinations(int[] array, int index, int currentNumber)
    {
        if (index == array.Length)
        {
            PrintArray(array);
        }
        else
        {
            for (int i = currentNumber; i <= n; i++)
            {
                array[index] = i;
                Combinations(array, index + 1, i + 1);
            }
        }
    }

    static void PrintArray(int[] array)
    {
        Console.Write("{");

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }

        Console.Write("{0}", symbol);
        Console.WriteLine("}");
    }

    static void Main()
    {
        int[] array = new int[k];
        Combinations(array, 0, 1);
    }
}