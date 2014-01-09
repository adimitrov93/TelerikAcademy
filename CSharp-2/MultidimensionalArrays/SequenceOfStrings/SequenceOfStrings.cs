//We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several neighbor elements located on the same line, column or diagonal. Write a program that finds the
//longest sequence of equal strings in the matrix. Example:

using System;

class SequenceOfStrings
{
    static int longestSeq = 0;
    static string longestSeqString = null;

    static int FindSequence(string[,] matrix, int startRow, int startCol)       //Checking for sequences
    {
        int currentSeq = 0;
        int maxSeq = 0;
        string currentString = matrix[startRow, startCol];

        for (int col = startCol; col < matrix.GetLength(1); col++)      //Checking horisontally for sequence
        {
            if (matrix[startRow, col].Equals(currentString))
            {
                currentSeq++;
            }
            else
            {
                break;
            }
        }

        if (currentSeq > maxSeq)
        {
            maxSeq = currentSeq;
        }

        currentSeq = 0;

        for (int row = startRow; row < matrix.GetLength(0); row++)      //Checking vertically for sequence
        {
            if (matrix[row, startCol].Equals(currentString))
            {
                currentSeq++;
            }
            else
            {
                break;
            }
        }

        if (currentSeq > maxSeq)
        {
            maxSeq = currentSeq;
        }

        currentSeq = 0;

        for (int row = startRow, col = startCol; row < matrix.GetLength(0) && col < matrix.GetLength(1); row++, col++)      //Checking diagonally from left to right
        {
            if (matrix[row, col].Equals(currentString))
            {
                currentSeq++;
            }
            else
            {
                break;
            }
        }

        if (currentSeq > maxSeq)
        {
            maxSeq = currentSeq;
        }

        currentSeq = 0;

        for (int row = startRow, col = startCol; row < matrix.GetLength(0) && col >= 0; row++, col--)      //Checking diagonally from right to left
        {
            if (matrix[row, col].Equals(currentString))
            {
                currentSeq++;
            }
            else
            {
                break;
            }
        }

        if (currentSeq > maxSeq)
        {
            maxSeq = currentSeq;
        }

        return maxSeq;
    }

    static void Main()
    {
        //string[,] matrix =
        //{
        //    {"ha", "fifi", "ho", "hi"},
        //    {"fo", "ha", "hi", "xx"},
        //    {"xxx", "ho", "ha", "xx"}
        //};

        string[,] matrix =
        {
            {"s", "qq", "s"},
            {"pp", "pp", "s"},
            {"pp", "qq", "s"}
        };

        int currentSeq = 0;

        //"Walking" throught the matrix
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                currentSeq = FindSequence(matrix, row, col);

                if (currentSeq > longestSeq)
                {
                    longestSeq = currentSeq;
                    longestSeqString = matrix[row, col];
                }
            }
        }

        //Print the result
        for (int i = 0; i < longestSeq; i++)
        {
            if (i < longestSeq - 1)
            {
                Console.Write("{0}, ", longestSeqString);                
            }
            else
            {
                Console.WriteLine("{0}", longestSeqString);
            }
        }
    }
}