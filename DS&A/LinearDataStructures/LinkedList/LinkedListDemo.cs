namespace LinkedList
{
    using System;

    public class LinkedListDemo
    {
        public static void Main()
        {
            var numbers = new LinkedList<int>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            Print(numbers);

            numbers.Remove(2);
            Print(numbers);

            numbers.Add(4);
            numbers.Remove(1);
            Print(numbers);

            numbers.Clear();
            Print(numbers);
        }

        private static void Print(LinkedList<int> linkedList)
        {
            foreach (var number in linkedList)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine(new string('-', 10));
        }
    }
}
