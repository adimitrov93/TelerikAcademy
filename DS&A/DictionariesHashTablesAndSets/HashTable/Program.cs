namespace HashTable
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var hashTable = new HashTable<string, int>();

            hashTable.Add("asdf", 1);
            hashTable.Add("qwerty", 2);
            hashTable.Add("zxc", 3);
            hashTable.Add("lorem", 4);
            hashTable.Add("ipsum", 5);

            Console.WriteLine("Count: " + hashTable.Count);
            Console.WriteLine("Capacity: " + hashTable.Capacity);

            foreach (var item in hashTable)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("asdf : " + hashTable.Find("asdf"));
            Console.WriteLine("qwerty : " + hashTable["qwerty"]);

            hashTable.Remove("asdf");

            Console.WriteLine("Count: " + hashTable.Count);
            Console.WriteLine("Capacity: " + hashTable.Capacity);

            foreach (var item in hashTable)
            {
                Console.WriteLine(item);
            }

            hashTable.Add("q", 1);
            hashTable.Add("w", 6);
            hashTable.Add("e", 7);
            hashTable.Add("r", 8);
            hashTable.Add("t", 9);
            hashTable.Add("y", 10);
            hashTable.Add("u", 11);
            hashTable.Add("s", 12);
            hashTable.Add("i", 13);
            hashTable.Add("o", 14);
            hashTable.Add("p", 15);
            hashTable.Add("a", 16);

            Console.WriteLine("Count: " + hashTable.Count);
            Console.WriteLine("Capacity: " + hashTable.Capacity);

            foreach (var item in hashTable)
            {
                Console.WriteLine(item);
            }
        }
    }
}
