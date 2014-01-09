using System;

class FirTree
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int height = n;
        int width = (n * 2) - 3;

        char[,] firTree = new char[height, width];

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                firTree[i, j] = '.';
            }
        }

        int position = (width / 2);
        int printOnPosition = position;
        int count = 1;

        firTree[height - 1, position] = '*';

        for (int i = 0; i < height - 1; i++)
        {
            printOnPosition = position;

            for (int j = 1; j <= count; j++)
            {
                firTree[i, printOnPosition] = '*';
                printOnPosition++;
            }

            count += 2;
            position--;
        }

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Console.Write(firTree[i, j]);
            }

            Console.WriteLine();
        }
    }
}