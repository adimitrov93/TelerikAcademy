namespace NumbersCounter
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
    /// </summary>
    public class NumbersCounter
    {
        public static void Main()
        {
            Console.WriteLine("Enter sequence of integers each one on a single line (empty line to stop):");
            var numbers = HandleInput();
            var counts = CountNumbers(numbers);
            Print(counts);
        }

        private static IList HandleInput()
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

            return numbers.ToArray();
        }

        private static IDictionary<int, int> CountNumbers(IList numbers)
        {
            var counter = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                var currentNumber = (int)numbers[i];

                if (counter.ContainsKey(currentNumber))
                {
                    counter[currentNumber]++;
                }
                else
                {
                    counter[currentNumber] = 1;
                }
            }

            return counter;
        }

        private static void Print(IEnumerable<KeyValuePair<int, int>> counts)
        {
            foreach (var entry in counts)
            {
                Console.WriteLine("{0} -> {1} {2}", entry.Key, entry.Value, entry.Value == 1 ? "time" : "times");
            }
        }
    }
}
