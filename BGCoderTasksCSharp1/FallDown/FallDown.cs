using System;

class FallDown
{
    static void Main()
    {
        int[] numbers = new int[8];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = byte.Parse(Console.ReadLine());
        }

        for (int k = 0; k < 7; k++)
        {
            for (int i = numbers.Length - 2; i >= 0; i--)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (((numbers[i] & (1 << j)) != 0) && ((numbers[i + 1] & (1 << j)) == 0))
                    {
                        numbers[i + 1] |= (1 << j);
                        numbers[i] &= (~(1 << j));
                    }
                }
            }
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}