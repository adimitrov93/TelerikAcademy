//* Write a program that reads three integer numbers N, K and S and an array of N elements from the console. Find in the array a subset of K elements that have sum S or indicate about its absence.

//This program uses almost the same algorithm like the previous task.

using System;
using System.Text;

class SubsetSum
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("k = ");
        int k = int.Parse(Console.ReadLine());

        Console.Write("s = ");
        int s = int.Parse(Console.ReadLine());

        int[] array = new int[n];

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("array[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        int condition = (int)Math.Pow(2, array.Length);
        int currentSum = 0;
        bool subsetFound = false;
        int count = 0;

        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 1; i < condition; i++)
        {
            count = 0;

            for (int j = array.Length - 1; j >= 0; j--)
            {
                if (((i >> j) & 1) != 0)
                {
                    count++;

                    currentSum += array[array.Length - j - 1];
                    if (stringBuilder.Length == 0)
                    {
                        stringBuilder.Append(array[array.Length - j - 1]);
                    }
                    else
                    {
                        stringBuilder.Append("+" + array[array.Length - j - 1]);
                    }
                }
            }

            if (currentSum == s && count == 3)
            {
                Console.WriteLine("yes({0})", stringBuilder);
                subsetFound = true;
            }

            currentSum = 0;
            stringBuilder.Clear();
        }

        if (!subsetFound)
        {
            Console.WriteLine("There is no subset with sum {0}.", s);
        }
    }
}