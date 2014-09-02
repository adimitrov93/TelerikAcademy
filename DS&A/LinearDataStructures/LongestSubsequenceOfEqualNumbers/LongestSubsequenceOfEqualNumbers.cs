namespace LongestSubsequenceOfEqualNumbers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Write a method that finds the longest subsequence of equal numbers in given List<int> and returns the result as new List<int>.
    /// </summary>
    public class LongestSubsequenceOfEqualNumbers
    {
        public static void Main()
        {
            Console.WriteLine("Enter sequence of integers each one on a single line (empty line to stop):");
            var numbers = HandleInput();

            var longestSubsequenceOfEqualNumbers = GetLongestSubsequenceOfEqualNumbers(numbers);
            Print(longestSubsequenceOfEqualNumbers);
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

        public static IList<int> GetLongestSubsequenceOfEqualNumbers(IList<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                throw new ArgumentNullException("numbers", "numbers cannot be null of empty");
            }

            var longestSequenceCount = 0;
            var longestSequenceNumber = 0;

            var currentSequenceCount = 1;
            var currentSequenceNumber = numbers[0];

            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] == currentSequenceNumber)
                {
                    currentSequenceCount++;
                }
                else
                {
                    if (currentSequenceCount > longestSequenceCount)
                    {
                        LongerSequenceFoundAssignments(ref longestSequenceCount, ref longestSequenceNumber, currentSequenceCount, currentSequenceNumber);
                    }

                    currentSequenceCount = 1;
                    currentSequenceNumber = numbers[i];
                }
            }

            if (longestSequenceCount == 0)
            {
                LongerSequenceFoundAssignments(ref longestSequenceCount, ref longestSequenceNumber, currentSequenceCount, currentSequenceNumber);
            }

            var result = new List<int>(longestSequenceCount);
            for (int i = 0; i < result.Capacity; i++)
            {
                result.Add(longestSequenceNumber);
            }

            return result;
        }

        // Done like that because of the DRY principle
        private static void LongerSequenceFoundAssignments(ref int longestSequenceCount, ref int longestSequenceNumber, int currentSequenceCount, int currentSequenceNumber)
        {
            longestSequenceCount = currentSequenceCount;
            longestSequenceNumber = currentSequenceNumber;
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
