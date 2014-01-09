//Write a program to calculate n! for each n in the range [1..100]. Hint: Implement first a method that multiplies a number represented as array of digits by given integer number. 

using System;
using System.Collections.Generic;

class NFactorial
{
    static int[] Addition(int[] a, int[] b)         //Used from the previous task
    {
        if (a.Length < b.Length)        //With that if we are sure that in a we have the longer number
        {
            int[] temp = b;
            b = a;
            a = temp;
        }

        int toAdd = 0;        //This holds 1 if we add two digits and their sum is > 9 Ex: 59 + 62 -> 9 + 2 = 11 => plusOne = 1
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

        if (toAdd == 1)
        {
            result.Add(toAdd);
        }

        return result.ToArray();
    }

    static int[] Multiplication(int[] a, int[] b)
    {
        //I suggest to debug this method for easy understanding
        int currentDigit;           //In the project folder there is a picture witch explains what this variables consist.
        int toAdd = 0;              //Here I keep the "overload" from multiplication Ex: 6 * 4 = 24, currentDigit = 4, toAdd = 2.
        List<int> addend;
        List<List<int>> addends = new List<List<int>>();

        for (int i = 0; i < a.Length; i++)
        {
            addend = new List<int>();

            for (int k = 0; k < i; k++)         //Adding zeros to the end of the addend. This zeros comes from the multiplication on paper,
            {                                   //where the addends moves 1 digit to the left.
                addend.Add(0);
            }

            for (int j = 0; j < b.Length; j++)
            {
                currentDigit = a[i] * b[j] + toAdd;

                toAdd = 0;

                if (currentDigit > 9)
                {
                    while (currentDigit > 9)
                    {
                        currentDigit -= 10;
                        toAdd++;
                    }
                }

                addend.Add(currentDigit);
            }

            if (toAdd != 0)
            {
                addend.Add(toAdd);
                toAdd = 0;
            }

            addends.Add(addend);
        }

        int[] result = { 0 };

        foreach (var item in addends)
        {
            result = Addition(result, item.ToArray());
        }

        return result;
    }

    static int[] NumberToArray(int number)          //Converts a number into reversed array of integers
    {
        int digit;
        List<int> numberInArray = new List<int>();

        while (number > 0)
        {
            digit = number % 10;
            number /= 10;
            numberInArray.Add(digit);
        }

        return numberInArray.ToArray();
    }

    static void MultiplicationTest()                //Automated test for the Multiplication method
    {
        Random randomGenerator = new Random();
        int[] firstNumber = NumberToArray(randomGenerator.Next());
        int[] secondNumber = NumberToArray(randomGenerator.Next());
        int[] result = Multiplication(firstNumber, secondNumber);

        Array.Reverse(firstNumber);
        Array.Reverse(secondNumber);
        Array.Reverse(result);

        Console.WriteLine("{0} * {1} = {2}", String.Join("", firstNumber), String.Join("", secondNumber), String.Join("", result));
    }

    static void Main()
    {
        //MultiplicationTest();         //Uncomment to run the automated test of the Multiplication method

        int n = 99;
        int[] nFaktorial = { 1 };
        int[] currentNumber;

        for (int i = 2; i <= n; i++)
        {
            currentNumber = NumberToArray(i);
            nFaktorial = Multiplication(currentNumber, nFaktorial);
        }

        Array.Reverse(nFaktorial);

        Console.WriteLine("{0}! = {1}", n, String.Join("", nFaktorial));
    }
}