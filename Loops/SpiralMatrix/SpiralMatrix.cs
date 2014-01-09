//* Write a program that reads a positive integer number N (N < 20) from console and outputs in the console the numbers 1 ... N numbers arranged as a spiral.

using System;

class SpiralMatrix
{
    static void Main()
    {
        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];
        string direction = "right";
        int rotations = n * n;

        for (int i = 1, row = 0, col = 0; i <= rotations; i++)
        {
            if (direction == "right" && ((col == n) || (matrix[row, col] != 0)))
            {
                direction = "down";
                col--;
                row++;
            }
            else if (direction == "down" && ((row == n) || (matrix[row, col] != 0)))
            {
                direction = "left";
                row--;
                col--;
            }
            else if (direction == "left" && ((col < 0) || (matrix[row, col] != 0)))
            {
                direction = "up";
                col++;
                row--;
            }
            else if (direction == "up" && (matrix[row, col] != 0))
            {
                direction = "right";
                row++;
                col++;
            }

            matrix[row, col] = i;

            if (direction == "right")
            {
                col++;
            }
            else if (direction == "down")
            {
                row++;
            }
            else if (direction == "left")
            {
                col--;
            }
            else if (direction == "up")
            {
                row--;
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0, 4}", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}