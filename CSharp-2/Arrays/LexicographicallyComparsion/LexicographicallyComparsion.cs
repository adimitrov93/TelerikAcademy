//Write a program that compares two char arrays lexicographically (letter by letter).

using System;

class LexicographicallyComparsion
{
    static void Main()
    {
        Console.Write("Enter the words that will be compared: ");

        string first = Console.ReadLine();
        string second = Console.ReadLine();

        char[] firstArray = first.ToCharArray();
        char[] secondArray = second.ToCharArray();

        int condition = Math.Min(firstArray.Length, secondArray.Length);

        bool areEqual = true;

        for (int i = 0; i < condition; i++)
        {
            if (firstArray[i] != secondArray[i])
            {
                areEqual = false;

                if (firstArray[i] < secondArray[i])
                {
                    Console.WriteLine("{0} is before {1}.", first, second);
                }
                else
                {
                    Console.WriteLine("{0} is before {1}.", second, first);
                }

                return;
            }
        }

        if (areEqual && (firstArray.Length < secondArray.Length))
        {
            Console.WriteLine("{0} is before {1}.", first, second);
        }
        else if (areEqual && (firstArray.Length > secondArray.Length))
        {
            Console.WriteLine("{0} is before {1}.", second, first);
        }
        else
        {
            Console.WriteLine("The words are equal.");
        }
    }
}