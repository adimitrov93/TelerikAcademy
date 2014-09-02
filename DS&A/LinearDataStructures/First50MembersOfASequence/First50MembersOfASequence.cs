namespace First50MembersOfASequence
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// We are given the following sequence. S1 = N; S2 = S1 + 1; S3 = 2*S1 + 1; S4 = S1 + 2; S5 = S2 + 1; S6 = 2*S2 + 1; S7 = S2 + 2; ...
    /// Using the Queue<T> class write a program to print its first 50 members for given N.
    /// </summary>
    public class First50MembersOfASequence
    {
        public static void Main()
        {
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());

            PrintFirstMembersOfTheSequence(n, 50);
        }

        private static void PrintFirstMembersOfTheSequence(int startingNumber, int count)
        {
            var resultSequence = new List<int>();
            var sequence = new Queue<int>();

            resultSequence.Add(startingNumber);
            sequence.Enqueue(startingNumber);


            for (int i = 1, seqIndex = 1; i < count; i++, seqIndex++)
            {
                int nextNumber;

                if (seqIndex == 1)
                {
                    nextNumber = sequence.Peek() + 1;
                }
                else if (seqIndex == 2)
                {
                    nextNumber = sequence.Peek() * 2 + 1;
                }
                else
                {
                    nextNumber = sequence.Dequeue() + 2;

                    seqIndex = 0;
                }

                resultSequence.Add(nextNumber);
                sequence.Enqueue(nextNumber);
            }

            Console.WriteLine(string.Join(", ", resultSequence));
        }
    }
}
