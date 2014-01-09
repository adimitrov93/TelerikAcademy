using System;

class TheBiggestSmallerOrEqualToYours
{
    static void Main()
    {
        //In this task I don't use BinarySearch because in my algorithm i need the last index of the searched element. BinarySearch returns the first index. With binary search must be added few if statements.

        Console.Write("n = ");

        int n = int.Parse(Console.ReadLine());

        Console.Write("k = ");

        int k = int.Parse(Console.ReadLine());

        int[] arrayOfNumbers = new int[n + 1];          //I add one additional element with value k. I need it to search towards it for the searched element.

        for (int i = 0; i < n; i++)
        {
            Console.Write("arrayOfNumbers[{0}] = ", i);

            arrayOfNumbers[i] = int.Parse(Console.ReadLine());
        }

        arrayOfNumbers[n] = k;

        Array.Sort(arrayOfNumbers);

        int searchedElement = Array.LastIndexOf(arrayOfNumbers, k);

        Console.WriteLine("The biggest element that is smaller or equal to k is {0}.", arrayOfNumbers[searchedElement - 1]);
    }
}