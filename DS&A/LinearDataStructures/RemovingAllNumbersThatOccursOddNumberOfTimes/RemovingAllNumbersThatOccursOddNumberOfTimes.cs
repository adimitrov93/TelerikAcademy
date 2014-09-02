namespace RemovingAllNumbersThatOccursOddNumberOfTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Write a program that removes from given sequence all numbers that occur odd number of times.
    /// </summary>
    public static class RemovingAllNumbersThatOccursOddNumberOfTimes
    {
        public static void Main()
        {
            Console.WriteLine("Enter sequence of integers each one on a single line (empty line to stop):");
            var numbers = HandleInput();
            RemoveNumbersThatOccursOddNumberOfTimes(numbers);
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

        private static void RemoveNumbersThatOccursOddNumberOfTimes(IList<int> numbers)
        {
            var counter = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                var currentNumber = numbers[i];

                if (counter.ContainsKey(currentNumber))
                {
                    counter[currentNumber]++;
                }
                else
                {
                    counter[currentNumber] = 1;
                }
            }

            foreach (var entry in counter)
            {
                if (entry.Value % 2 != 0)
                {
                    numbers.RemoveAll(entry.Key);
                }
            }
        }

        private static void RemoveAll<T>(this IList<T> list, T value)
        {
            while (list.Remove(value))
            {
            }
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
