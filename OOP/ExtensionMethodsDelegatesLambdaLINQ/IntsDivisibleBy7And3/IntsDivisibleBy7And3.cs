//Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

namespace IntsDivisibleBy7And3
{
    using System;
    using System.Linq;

    public class IntsDivisibleBy7And3
    {
        public static void Main()
        {
            int[] arrayOfNumbers = { 5, 6, 42, 84, 65, 99, 126 };

            var extractedWithLambda = arrayOfNumbers.Where(x => (x % 21) == 0);

            //foreach (var number in extractedWithLambda)
            //{
            //    Console.WriteLine(number);
            //}

            var extractedWithLINQ =
                from number in arrayOfNumbers
                where (number % 21) == 0
                select number;

            //foreach (var number in extractedWithLINQ)
            //{
            //    Console.WriteLine(number);
            //}
        }
    }
}
