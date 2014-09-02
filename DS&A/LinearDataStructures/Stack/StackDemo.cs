namespace Stack
{
    using System;

    public class StackDemo
    {
        public static void Main()
        {
            var numbers = new Stack<int>();
            numbers.Push(1);
            numbers.Push(2);
            numbers.Push(3);
            numbers.Push(4);
            Print(numbers);

            numbers.Push(5);
            Print(numbers);

            Console.WriteLine("Popped: {0}", numbers.Pop());
            Print(numbers);

            numbers.Push(5);
            Print(numbers);

            Console.WriteLine("Peeked: {0}", numbers.Peek());
            Print(numbers);
        }

        private static void Print(Stack<int> numbers)
        {
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine(new string('-', 10));
        }
    }
}
