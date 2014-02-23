namespace BitArray64Program
{
    using System;

    public class BitArray64Program
    {
        public static void Main()
        {
            BitArray64 someNumber = new BitArray64(43);
            BitArray64 anotherNumber = new BitArray64(43);

            Console.WriteLine(someNumber.Equals(anotherNumber));

            foreach (var bit in someNumber)
            {
                Console.Write(bit);
            }

            Console.WriteLine();

            someNumber[10] = 1;

            foreach (var bit in someNumber)
            {
                Console.Write(bit);
            }

            Console.WriteLine();

            Console.WriteLine(someNumber[10]);

            someNumber[0] = 0;

            Console.WriteLine(someNumber[0]);

            foreach (var bit in someNumber)
            {
                Console.Write(bit);
            }

            Console.WriteLine();

            Console.WriteLine(someNumber.GetHashCode());
            Console.WriteLine(anotherNumber.GetHashCode());
        }
    }
}
