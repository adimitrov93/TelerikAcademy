//Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end]. If an invalid number or non-number text is entered, the method should throw an exception. Using this method write a program that enters 10 numbers:
//			a1, a2, … a10, such that 1 < a1 < … < a10 < 100

using System;

class Enter10Numbers
{
    const int sizeOfArray = 10;
    static int EnterNumber(int start, int end)
    {
        Console.Write("Enter number between {0} and {1}: ", start, end);
        int number;

        if (!int.TryParse(Console.ReadLine(), out number))
        {
            throw new FormatException("The input is not a number.");
        }

        if (number <= start || number >= end)
        {
            throw new IndexOutOfRangeException("Your number is out of range.");
        }

        return number;
    }

    static void Main()
    {
        int[] arrayOfNumbers = new int[sizeOfArray];
        int start = 1, end = 91;

        for (int i = 0; i < arrayOfNumbers.Length; i++)
        {
            try
            {
                arrayOfNumbers[i] = EnterNumber(start, end);
                start = arrayOfNumbers[i];
                end++;
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}