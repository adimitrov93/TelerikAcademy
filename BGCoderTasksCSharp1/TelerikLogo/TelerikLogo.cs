using System;

class TelerikLogo
{
    static void Main()
    {
        int x = int.Parse(Console.ReadLine());
        int z = (x / 2) + 1;
        int arraySize = (x * 2) + (x - 2);
        char[,] logo = new char[arraySize, arraySize];
        int i, j;

        for (i = 0; i < arraySize; i++)
        {
            for (j = 0; j < arraySize; j++)
            {
                logo[i, j] = '.';
            }
        }

        for (i = x / 2, j = 0; i >= 0; i--, j++)
        {
            logo[i, j] = '*';
        }

        for (i = 1; i < (x * 2 - 1); i++, j++)
        {
            logo[i, j] = '*';
        }

        for (j -= 2; i < arraySize; i++, j--)
        {
            logo[i, j] = '*';
        }

        for (i -= 2; i >= (x * 2 - 2); i--, j--)
        {
            logo[i, j] = '*';
        }

        for (j += 2; i >= 0; i--, j++)
        {
            logo[i, j] = '*';
        }

        for (i += 2; i <= (x / 2); i++, j++)
        {
            logo[i, j] = '*';
        }

        for (i = 0; i < arraySize; i++)
        {
            for (j = 0; j < arraySize; j++)
            {
                Console.Write(logo[i, j]);
            }
            Console.WriteLine();
        }
    }
}