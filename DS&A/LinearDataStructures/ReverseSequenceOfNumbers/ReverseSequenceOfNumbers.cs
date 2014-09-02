namespace ReverseSequenceOfNumbers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Write a program that reads N integers from the console and reverses them using a stack. Use the Stack<int> class.
    /// </summary>
    public class ReverseSequenceOfNumbers
    {
        public static void Main()
        {
            Console.Write("Enter number of integers: ");
            int numberOfIntegers = int.Parse(Console.ReadLine());

            var integers = new Stack<int>();
            for (int i = 0; i < numberOfIntegers; i++)
            {
                Console.Write("Enter {0} more integers: ", numberOfIntegers - i);
                int currentInteger = int.Parse(Console.ReadLine());

                integers.Push(currentInteger);
            }

            Console.WriteLine("The same integers in reversed order:");
            foreach (var integer in integers)
            {
                Console.WriteLine(integer);
            }
        }
    }
}
