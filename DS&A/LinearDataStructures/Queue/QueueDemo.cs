namespace Queue
{
    using System;

    public class QueueDemo
    {
        public static void Main()
        {
            var numbers = new Queue<int>();

            numbers.Enqueue(1);
            numbers.Enqueue(2);
            numbers.Enqueue(3);
            Print(numbers);

            Console.WriteLine("Dequeued: {0}", numbers.Dequeue());
            Print(numbers);

            numbers.Enqueue(4);
            Console.WriteLine("Peeked: {0}", numbers.Peek());
            Print(numbers);
        }

        private static void Print(Queue<int> numbers)
        {
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine(new string('-', 10));
        }
    }
}
