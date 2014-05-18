//Write a program that finds all prime numbers in the range [1...10 000 000]. Use the sieve of Eratosthenes algorithm (find it in Wikipedia).

using System;

class SieveOfEratosthenes
{
    static void Main()
    {
        bool[] numbers = new bool[1000000000];                    //An array for every number in the range 1...10 000 000

        int condition = (int)Math.Sqrt(numbers.Length);         //This is an optimisation for faster runtime

        for (int i = 2; i < condition; i++)
        {
            if (!numbers[i])                                    //In fact the values of the element must be true = prime and false = not prime, but in this way is a lil bit faster
            {
                for (int j = i * i; j < numbers.Length; j += i)
                {
                    numbers[j] = true;
                }
            }
        }

        for (int i = 2; i < 1000; i++)
        {
            if (!numbers[i])
            {
                Console.WriteLine(i);
            }
        }
    }
}