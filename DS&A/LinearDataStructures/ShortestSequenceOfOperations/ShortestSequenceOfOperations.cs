namespace ShortestSequenceOfOperations
{
    using System;
    using System.Collections.Generic;

    public class ShortestSequenceOfOperations
    {
        public static void Main()
        {
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("M = ");
            int m = int.Parse(Console.ReadLine());

            Console.WriteLine(FindShortestSequence(n, m));
        }

        // I used stack instead of queue, because I find out algorithm that works with stack, but i didn't figure out how to do it with queue.
        private static string FindShortestSequence(int startNumber, int endNumber)
        {
            if (startNumber > endNumber)
            {
                startNumber += endNumber;
                endNumber = startNumber - endNumber;
                startNumber -= endNumber;
            }

            var steps = new Stack<int>();
            steps.Push(endNumber);

            while (true)
            {
                int topNumber = steps.Peek();

                if (topNumber == startNumber)
                {
                    break;
                }

                if (topNumber / 2 >= startNumber)
                {
                    if (topNumber % 2 == 0)
                    {
                        steps.Push(topNumber / 2);
                    }
                    else
                    {
                        steps.Push(topNumber - 1);
                    }
                }
                else if (topNumber - 2 >= startNumber)
                {
                    steps.Push(topNumber - 2);
                }
                else if (topNumber - 1 >= startNumber)
                {
                    steps.Push(topNumber - 1);
                }
            }

            return string.Join(" -> ", steps);
        }
    }
}
