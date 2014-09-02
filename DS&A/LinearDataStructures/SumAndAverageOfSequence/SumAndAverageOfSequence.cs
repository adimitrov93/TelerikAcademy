namespace SumAndAverageOfSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Write a program that reads from the console a sequence of positive integer numbers. The sequence ends when empty line is entered.
    /// Calculate and print the sum and average of the elements of the sequence. Keep the sequence in List<int>.
    /// </summary>
    public class SumAndAverageOfSequence
    {
        public static void Main()
        {
            Console.WriteLine("Enter sequence of positive integer numbers each one on a single line (empty line to stop):");
            var numbers = HandleInput();

            var sum = Sum(numbers);
            var average = Average(numbers);

            Console.WriteLine("The sum of the elements is {0}", sum);
            Console.WriteLine("The average of the elements is {0}", average);
        }

        private static IEnumerable<int> HandleInput()
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

                if (isParseSuccessful && currentNumber > 0)
                {
                    numbers.Add(currentNumber);
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            return numbers;
        }

        private static int Sum(IEnumerable<int> numbers)
        {
            int sum = 0;

            foreach (var number in numbers)
            {
                sum += number;
            }

            return sum;
        }

        private static double Average(IEnumerable<int> numbers)
        {
            double sum = Sum(numbers);

            return sum / numbers.Count();
        }
    }
}