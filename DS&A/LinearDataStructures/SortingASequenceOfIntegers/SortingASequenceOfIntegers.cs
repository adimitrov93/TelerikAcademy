namespace SortingASequenceOfIntegers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Write a program that reads a sequence of integers (List<int>) ending with an empty line and sorts them in an increasing order.
    /// </summary>
    public class SortingASequenceOfIntegers
    {
        public static void Main()
        {
            Console.WriteLine("Enter sequence of integers each one on a single line (empty line to stop):");
            var numbers = HandleInput();
            InsertionSort(numbers);
            Print(numbers);
        }

        private static IList<int> HandleInput()
        {
            var numbers = new List<int>();

            while (true)
            {
                var inputLine = Console.ReadLine();

                if (inputLine == "")
                {
                    break;
                }

                int currentNumber;

                var isParseSuccessful = int.TryParse(inputLine, out currentNumber);

                if (isParseSuccessful)
                {
                    numbers.Add(currentNumber);
                }
            }

            return numbers;
        }

        private static void InsertionSort(IList<int> numbers)
        {
            for (int i = 1; i < numbers.Count; i++)
            {
                var j = i;

                while (j > 0 && numbers[j - 1] > numbers[j])
                {
                    Swap(numbers, j, j - 1);
                    j--;
                }
            }
        }

        private static void Swap(IList<int> numbers, int firstIndex, int secondIndex)
        {
            // Done like that because of the KISS principle
            var firstCopy = numbers[firstIndex];
            numbers[firstIndex] = numbers[secondIndex];
            numbers[secondIndex] = firstCopy;
        }

        private static void Print(IEnumerable<int> numbers)
        {
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}