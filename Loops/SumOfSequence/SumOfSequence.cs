//Write a program that, for a given two integer numbers N and X, calculates the sumS = 1 + 1!/X + 2!/X^2 + … + N!/X^N

using System;

class SumOfSequence
{
    static void Main()
    {
        Console.WriteLine("The program calculates the sum S = 1 + 1!/X + 2!/X^2 + … + N!/X^N");
        Console.WriteLine("Enter N and X: ");
        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("X = ");
        int x = int.Parse(Console.ReadLine());

        decimal sum = 1, nFactorial = 1, xToThePowerOfN = x;

        for (int i = 1; i <= n; i++, nFactorial *= i, xToThePowerOfN *= x)
        {
            sum += nFactorial / xToThePowerOfN;
        }

        Console.WriteLine("S = {0}", sum);
    }
}