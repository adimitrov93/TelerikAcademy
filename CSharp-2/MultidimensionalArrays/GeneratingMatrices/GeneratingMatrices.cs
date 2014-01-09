//Write a program that fills and prints a matrix of size (n, n) as shown below:

using System;

class GeneratingMatrices
{
    static int n = 10;
    static int[,] matrix = new int[n, n];

    static void VerticalMatrix()                    //This is easy. I don't think there is need to explain it.
    {
        int counter = 1;

        for (int col = 0; col < n; col++)
        {
            for (int row = 0; row < n; row++)
            {
                matrix[row, col] = counter;
                counter++;
            }
        }

        PrintMatrix();
    }

    static void SnakeMoveMatrix()                   //Almost like the vertical matrix. There is only one additional check - if the col is even we print from top to bottom. If the col is odd - the opposite.
    {
        int counter = 1;

        for (int col = 0; col < n; col++)
        {
            if (col % 2 == 0)
            {
                for (int row = 0; row < n; row++)
                {
                    matrix[row, col] = counter;
                    counter++;
                }
            }
            else
            {
                for (int row = n - 1; row >= 0; row--)
                {
                    matrix[row, col] = counter;
                    counter++;
                }
            }
        }

        PrintMatrix();
    }

    static void TriangleMatrix()                    //I suggest to debug itq because i can't explain it so simply. Note: use F11 to enter the methods. F10 will just pass them.
    {
        NullMatrix();                               //This method is nessesary, because FindLowestRow and FindLowestCol use the empty places to find the lowest rows and cols

        int counter = 1;
        int move = 1;
        int row = 0;
        int col = 0;

        for (int i = 0; i < n * n; i++)
        {
            row = FindBiggestRow();

            if (row != -1)                          //If there is row with empty first cell
            {
                col = 0;

                for (int j = 0; j < move; j++)
                {
                    matrix[row, col] = counter;

                    counter++;

                    row++;
                    col++;
                }
            }
            else
            {
                col = FindLowestCol();

                if (col != -1)
                {
                    row = 0;

                    for (int j = 0; j < move; j++)
                    {
                        matrix[row, col] = counter;

                        counter++;

                        row++;
                        col++;
                    }
                }
                else
                {
                    break;
                }
            }

            if (FindBiggestRow() != -1)                 //If there are no more empty first cells we continue to increase the count of cells we need to move.
            {
                move++;
            }
            else
            {
                move--;
            }
        }

        PrintMatrix();
    }

    static int FindBiggestRow()                     //Returns the biggest row that have empty first cell.
    {
        for (int i = (n - 1); i >= 0; i--)
        {
            if (matrix[i, 0] == 0)
            {
                return i;
            }
        }

        return -1;                      //If first columns at all rows are already full
    }

    static int FindLowestCol()                      //Returns the lowerst col with empty cell on the first line.
    {
        for (int i = 0; i < n; i++)
        {
            if (matrix[0, i] == 0)
            {
                return i;
            }
        }

        return -1;                                   //If all columns at the first row are full
    }

    static void SpiralMatrix()                      //"Walking" thought the matrix and filling it up with numbers. It uses that on every odd iteration the cells we need to move decreases by one.
    {
        int counter = 1;
        int move = n;
        string direction = "down";
        int row = 0;
        int col = 0;

        for (int i = 0; i < 2 * n; i++)
        {
            if (i % 2 != 0)
            {
                move--;
            }

            if (direction.Equals("down"))
            {
                int currentRow = row;

                for (int j = 0; j < move; j++)
                {
                    matrix[currentRow, col] = counter;
                    currentRow++;
                    counter++;

                    if (j == (move - 1))
                    {
                        row = currentRow - 1;
                        col++;
                        break;
                    }
                }
            }
            else if (direction.Equals("right"))
            {
                int currentCol = col;

                for (int j = 0; j < move; j++)
                {
                    matrix[row, currentCol] = counter;
                    currentCol++;
                    counter++;

                    if (j == (move - 1))
                    {
                        col = currentCol - 1;
                        row--;
                        break;
                    }
                }
            }
            else if (direction.Equals("up"))
            {
                int currentRow = row;

                for (int j = 0; j < move; j++)
                {
                    matrix[currentRow, col] = counter;
                    currentRow--;
                    counter++;

                    if (j == (move - 1))
                    {
                        row = currentRow + 1;
                        col--;
                        break;
                    }
                }
            }
            else
            {
                int currentCol = col;

                for (int j = 0; j < move; j++)
                {
                    matrix[row, currentCol] = counter;
                    currentCol--;
                    counter++;

                    if (j == (move - 1))
                    {
                        col = currentCol + 1;
                        row++;
                        break;
                    }
                }
            }

            ChangeDirection(ref direction);
        }

        PrintMatrix();
    }

    static void ChangeDirection(ref string direction)   //This method change the direction of "walking" thought the matrix. If it is "down" it makes it "right", if it is "right" it makes it "up", etc.
    {
        //This word "ref" is used to pass this method the address in the memory of this variable, not copy of it.

        if (direction.Equals("down"))
        {
            direction = "right";
        }
        else if (direction.Equals("right"))
        {
            direction = "up";
        }
        else if (direction.Equals("up"))
        {
            direction = "left";
        }
        else
        {
            direction = "down";
        }
    }

    static void NullMatrix()                        //Make all elements 0.
    {
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                matrix[row, col] = 0;
            }
        }
    }

    static void PrintMatrix()                       //Print the matrix on the console.
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0,-5}", matrix[i, j]);
            }

            Console.WriteLine();
        }
    }

    static void Main()
    {
        VerticalMatrix();

        Console.WriteLine();

        SnakeMoveMatrix();

        Console.WriteLine();

        TriangleMatrix();

        Console.WriteLine();

        SpiralMatrix();
    }
}