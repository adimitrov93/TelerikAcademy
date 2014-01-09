//Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.

using System;

class CheckIfPrime
{
    static void Main()
    {
        Console.Write("Enter a positive integer number: ");
        uint userInput = uint.Parse(Console.ReadLine());

        bool isPrime = true;

        if (userInput == 0 || userInput == 1)
        {
            Console.WriteLine("{0} is not prime.", userInput);
        }
        else if (userInput == 2 || userInput == 3)
        {
            Console.WriteLine("{0} is prime.", userInput);
        }
        else
        {
            for (int i = 2; i <= Math.Sqrt(userInput); i++)
            {
                if (userInput % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            Console.WriteLine(isPrime ? "{0} is prime." : "{0} is not prime", userInput);
        }
    }
}