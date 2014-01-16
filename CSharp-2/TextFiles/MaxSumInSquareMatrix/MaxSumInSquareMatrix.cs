//Write a program that reads a text file containing a square matrix of numbers and finds in the matrix an area of size 2 x 2 with a maximal sum of its elements. The first line in the input file
//contains the size of matrix N. Each of the next N lines contain N numbers separated by space. The output should be a single number in a separate text file. Example:

using System;
using System.IO;
using System.Text;

class MaxSumInSquareMatrix
{
    static string AddBackslashes(string inputString)
    {
        StringBuilder outputString = new StringBuilder(inputString);

        for (int i = 0; i < outputString.Length; i++)
        {
            if (outputString[i] == '\\')
            {
                outputString.Insert(i + 1, '\\');
                i++;
            }
        }

        return outputString.ToString();
    }

    static int[,] StringToMatrix(string data)
    {
        try
        {
            string[] splittedString = data.Split(' ', '\n');

            int size = int.Parse(splittedString[0]);
            int[,] matrixOfNumbers = new int[size, size];
            int counter = 1;

            for (int row = 0; row < matrixOfNumbers.GetLength(0); row++)
            {
                for (int col = 0; col < matrixOfNumbers.GetLength(1); col++, counter++)
                {
                    matrixOfNumbers[row, col] = int.Parse(splittedString[counter]);
                }
            }

            return matrixOfNumbers;
        }
        catch (Exception)
        {
            throw new FormatException();
        }
        
    }

    static int FindMaxSum(int[,] matrixOfNumbers)
    {
        int currentSum = 0, maxSum = 0;

        for (int row = 0; row < matrixOfNumbers.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrixOfNumbers.GetLength(1) - 1; col++)
            {
                currentSum = matrixOfNumbers[row, col] + matrixOfNumbers[row + 1, col] + matrixOfNumbers[row, col + 1] + matrixOfNumbers[row + 1, col + 1];

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }
        }

        return maxSum;
    }

    static void Main()
    {
        Console.Write("Enter the path to the input file: ");
        string input = Console.ReadLine();

        Console.Write("Enter the path to the output file: ");
        string output = Console.ReadLine();

        input = AddBackslashes(input);
        output = AddBackslashes(output);

        try
        {
            StreamReader reader = new StreamReader(input);
            StreamWriter writer = new StreamWriter(output);
            int maxSum = 0;

            using (reader)
            {
                string data = reader.ReadToEnd();
                int[,] matrixOfNumbers = StringToMatrix(data);
                maxSum = FindMaxSum(matrixOfNumbers);
            }

            using (writer)
            {
                writer.WriteLine(maxSum);
            }

            Console.WriteLine("Operation finished seccessfully.");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("The path cannot be empty.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid matrix.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Invalid path.");
        }
        catch (IOException)
        {
            Console.WriteLine("An I/O error occurred while performing the requested operation.");
        }
    }
}