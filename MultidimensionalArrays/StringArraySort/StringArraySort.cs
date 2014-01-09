//You are given an array of strings. Write a method that sorts the array by the length of its elements (the number of characters composing them).

using System;

class StringArraySort
{
    static string[] arrayOfStrings =
    {
        "Pesho",
        "Ivan",
        "Toi",
        "E",
        "Bolnica",
        "Apteka"
    };

    static void StringArraySorter()                         //Implements Selection Sort Algorithm.
    {
        for (int i = 0; i < arrayOfStrings.Length - 1; i++)
        {
            Swap(i, FindShrotest(i));
        }
    }

    static int FindShrotest(int start)                      //Finds the smallest string.
    {
        int shortestLenght = int.MaxValue;
        int shortestPosition = 0;

        for (int i = start; i < arrayOfStrings.Length; i++)
        {
            if (arrayOfStrings[i].Length < shortestLenght)
            {
                shortestLenght = arrayOfStrings[i].Length;
                shortestPosition = i;
            }
        }

        return shortestPosition;
    }

    static void Swap(int first, int second)                 //Swap two string by their indexes
    {
        string temp;

        temp = arrayOfStrings[first];
        arrayOfStrings[first] = arrayOfStrings[second];
        arrayOfStrings[second] = temp;
    }

    static void PrintArray()                                //Print the array
    {
        Console.WriteLine(String.Join(", ", arrayOfStrings));
    }

    static void Main()
    {
        StringArraySorter();

        PrintArray();
    }
}