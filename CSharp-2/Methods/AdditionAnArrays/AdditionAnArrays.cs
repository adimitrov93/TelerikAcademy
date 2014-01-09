//Write a method that adds two positive integer numbers represented as arrays of digits (each array element arr[i] contains a digit; the last digit is kept in arr[0]).
//Each of the numbers that will be added could have up to 10 000 digits.

using System;
using System.Collections.Generic;

class AdditionAnArrays
{
    static int[] Addition(int[] a, int[] b)
    {
        if (a.Length < b.Length)        //With that if we are sure that in a we have the longer number
        {
            int[] temp = b;
            b = a;
            a = temp;
        }

        int toAdd = 0;        //This holds 1 if we add two digits and their sum is > 9 Ex: 59 + 62 -> 9 + 2 = 11 => toAdd = 1
        int currentDigit;
        List<int> result = new List<int>();

        for (int i = 0, j = 0; i < a.Length; i++)
        {
            if (j < b.Length)
            {
                currentDigit = a[i] + b[j] + toAdd;
                j++;
            }
            else
            {
                currentDigit = a[i] + toAdd;
            }

            toAdd = 0;

            if (currentDigit > 9)
            {
                toAdd = 1;
                currentDigit %= 10;
            }

            result.Add(currentDigit);
        }

        if (toAdd != 0)
        {
            result.Add(toAdd);
        }

        return result.ToArray();
    }

    static void Main()
    {
        int[] firstNumber = { 2, 4, 5 };        //542
        int[] secondNumber = { 2, 6, 7};        //762

        int[] result = Addition(firstNumber, secondNumber);

        Array.Reverse(firstNumber);
        Array.Reverse(secondNumber);
        Array.Reverse(result);

        Console.WriteLine("{0} + {1} = {2}", String.Join("", firstNumber), String.Join("", secondNumber), String.Join("", result));
    }
}