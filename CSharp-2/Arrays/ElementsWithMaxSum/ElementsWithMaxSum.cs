//Write a program that reads two integer numbers N and K and an array of N elements from the console. Find in the array those K elements that have maximal sum.

using System;

class ElementsWithMaxSum
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("k = ");
        int k = int.Parse(Console.ReadLine());

        if (n < k)
        {
            Console.WriteLine("n must be bigger than k!");
            return;
        }

        int[] array = new int[n];
        int[] maxSum = new int[k];                      //I use this array to save the maximum numbers that are stored in array

        Console.WriteLine("Enter {0} elements:", n);

        for (int i = 0; i < n; i++)
        {
            Console.Write("array[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }


        //I make the elements in maxSum equal to the first k elements in array
        for (int i = 0; i < k; i++)
        {
            maxSum[i] = array[i];
        }

        for (int i = k; i < n; i++)
        {
            for (int j = 0; j < k; j++)
            {
                if (array[i] > maxSum[j])                   //Check if some element in array is bigger than some element in maxSum
                {
                    maxSum[j] = array[i];                   //If so, i make that maxSum element equal to the array element
                    break;
                }
            }
        }

        Console.Write("{");

        for (int i = 0; i < k; i++)
        {
            if (i == (k - 1))
            {
                Console.Write("{0}", maxSum[i]);
            }
            else
            {
                Console.Write("{0}, ", maxSum[i]);
            }
        }

        Console.WriteLine("}");

    }
}