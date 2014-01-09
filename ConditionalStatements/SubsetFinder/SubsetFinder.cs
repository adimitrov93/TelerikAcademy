//We are given 5 integer numbers. Write a program that checks if the sum of some subset of them is 0. Example: 3, -2, 1, 1, 8  1+1-2=0.

using System;

class SubsetFinder
{
    static void Main()
    {
        Console.WriteLine("Enter 5 integer numbers:");

        Console.Write("1st: ");
        int firstInt = int.Parse(Console.ReadLine());

        Console.Write("2nd: ");
        int secondInt = int.Parse(Console.ReadLine());

        Console.Write("3rd: ");
        int thirdInt = int.Parse(Console.ReadLine());

        Console.Write("4th: ");
        int fourthInt = int.Parse(Console.ReadLine());

        Console.Write("5th: ");
        int fifthInt = int.Parse(Console.ReadLine());

        int sum, subsetCount = 0;

        /*
         * This method lies in that the binary representation of the numbers from 1 to 30 looks like that:
         * 00001
         * 00010
         * 00011
         * 00100
         * 00101
         * 00110
         * 00111
         * 01000
         * 01001
         * 01010
         * 01011
         * 01100
         * 01101
         * 01110
         * 01111
         * 10000
         * 10001
         * 10010
         * 10011
         * 10100
         * 10101
         * 10110
         * 10111
         * 11000
         * 11001
         * 11010
         * 11011
         * 11100
         * 11101
         * 11110
         * If every digit of that binary representation is one of the five integers, and when the digit is 1 the value of the corresponding int is added to sum variable,
         * this will run out every single subset combination. E.g. i = 10 (Binary: 01010) subset will be: secondInt + fourthInt.
         */

        for (int i = 1; i <= 30; i++)
        {
            sum = 0;

            if ((i & 1) == 1)
            {
                sum += fifthInt;
            }

            if (((i >> 1) & 1) == 1)
            {
                sum += fourthInt;
            }

            if (((i >> 2) & 1) == 1)
            {
                sum += thirdInt;
            }

            if (((i >> 3) & 1) == 1)
            {
                sum += secondInt;
            }

            if (((i >> 4) & 1) == 1)
            {
                sum += firstInt;
            }

            if (sum == 0)
            {
                subsetCount++;
            }
        }

        if (subsetCount == 0)
        {
            Console.WriteLine("There are no subsets equal to 0.");
        }
        else if (subsetCount == 1)
        {
            Console.WriteLine("There is 1 subset equal to 0.");
        }
        else
        {
            Console.WriteLine("There are {0} subsets equal to 0.", subsetCount);
        }
    }
}