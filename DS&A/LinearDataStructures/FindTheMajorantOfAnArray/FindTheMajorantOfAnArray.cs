namespace FindTheMajorantOfAnArray
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// * The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times. Write a program to find the majorant of given array (if exists).
    /// </summary>
    public class FindTheMajorantOfAnArray
    {
        public static void Main()
        {
            Console.WriteLine("Enter sequence of integers each one on a single line (empty line to stop):");
            var numbers = HandleInput();

            var majorantIndex = FindMajorant(numbers);
            if (majorantIndex >= 0)
            {
                Console.WriteLine("Marjorant of the array is {0}", numbers[majorantIndex]);
            }
            else
            {
                Console.WriteLine("The array has no majorant.");
            }
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

        private static int FindMajorant(IList numbers)
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

                if (counter[currentNumber] >= ((numbers.Count / 2) + 1))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
