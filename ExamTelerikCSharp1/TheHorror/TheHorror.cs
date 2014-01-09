using System;

class Program
{
    static void Main()
    {
        String input = Console.ReadLine();

        char[] arr = input.ToCharArray();

        int number;
        int evenCount = 0;
        int sum = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            number = arr[i] - '0';

            if (i % 2 == 0)
            {
                if (number >= 0 && number <= 9)
                {
                    evenCount++;
                    sum += number;
                }
            }
        }

        Console.WriteLine("{0} {1}", evenCount, sum);
    }
}