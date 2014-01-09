//* We are given an array of integers and a number S. Write a program to find if there exists a subset of the elements of the array that has a sum S. Example:
//	arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14  yes (1+2+5+6)

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

using System;
using System.Text;

class SubsetSum
{
    static void Main()
    {
        int[] array = { 2, 1, 2, 4, 3, 5, 2, 6 };
        int s = 144;

        int condition = (int)Math.Pow(2, array.Length);
        int currentSum = 0;
        bool subsetFound = false;

        StringBuilder stringBuilder = new StringBuilder();                  //StringBuilder is somenthing like String but it can be changed runtime, because string is immutable i.e. can't be changed.

        for (int i = 1; i < condition; i++)
        {
            for (int j = array.Length - 1; j >= 0; j--)
            {
                if (((i >> j) & 1) != 0)
                {
                    currentSum += array[array.Length - j - 1];
                    if (stringBuilder.Length == 0)
                    {
                        stringBuilder.Append(array[array.Length - j - 1]);  //The method append concatenates the current string in the string builder with the value int the parentheses
                    }
                    else
                    {
                        stringBuilder.Append("+" + array[array.Length - j - 1]);
                    }
                }
            }

            if (currentSum == s)
            {
                Console.WriteLine("yes({0})", stringBuilder);
                subsetFound = true;
            }

            currentSum = 0;
            stringBuilder.Clear();
        }

        if (!subsetFound)
        {
            Console.WriteLine("There is no subset with sum {0}.", s);
        }
    }
}