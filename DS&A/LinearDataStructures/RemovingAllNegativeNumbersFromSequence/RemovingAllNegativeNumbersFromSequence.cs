namespace RemovingAllNegativeNumbersFromSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Write a program that removes from given sequence all negative numbers.
    /// </summary>
    public class RemovingAllNegativeNumbersFromSequence
    {
        public static void Main()
        {
            Console.WriteLine("Enter sequence of numbers each one on a single line (empty line to stop):");
            var numbers = HandleInput();

            // Easy way
            var onlyPositiveNumbers = numbers.Where(x => x >= 0);

            // Harder way
            // RemoveNegatives(numbers);

            Print(onlyPositiveNumbers);
        }

        private static IList<double> HandleInput()
        {
            var numbers = new List<double>();

            while (true)
            {
                var inputLine = Console.ReadLine();

                if (inputLine == "")
                {
                    break;
                }

                double currentNumber;

                var isParseSuccessful = double.TryParse(inputLine, out currentNumber);

                if (isParseSuccessful)
                {
                    numbers.Add(currentNumber);
                }
            }

            return numbers;
        }

        private static void Print(IEnumerable<double> numbers)
        {
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }

        private static void RemoveNegatives(IList<double> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
