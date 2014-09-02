namespace RotatingWalkInMatrix
{
    using System;

    public class MainProgram
    {
        public static void Main()
        {
            Console.Write("Enter a positive integer number (< 100): ");
            string userInputAsString = Console.ReadLine();
            int matrixSize;
            bool isParseSuccessful = int.TryParse(userInputAsString, out matrixSize);

            while (!isParseSuccessful || matrixSize < 0 || matrixSize > 100)
            {
                Console.WriteLine("Invalid number!");
                Console.Write("Enter a positive integer number (< 100): ");

                userInputAsString = Console.ReadLine();
                isParseSuccessful = int.TryParse(userInputAsString, out matrixSize);
            }

            int[,] matrix = Engine.PerformRotatingWalk(matrixSize);

            Printer.PrintMatrix(matrix);
        }
    }
}
