//Write a program that concatenates two text files into another text file.

using System;
using System.Text;
using System.IO;

class ConcatenateTwoFiles
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

    static void Main()
    {
        Console.Write("Enter path to first input file: ");
        string firstInputFile = Console.ReadLine();

        Console.Write("Enter path to seccond input file: ");
        string secondInputFile = Console.ReadLine();

        Console.Write("Enter path to the output file: ");
        string outputFile = Console.ReadLine();

        firstInputFile = AddBackslashes(firstInputFile);
        secondInputFile = AddBackslashes(secondInputFile);
        outputFile = AddBackslashes(outputFile);

        try
        {
            StreamReader firstInput = new StreamReader(firstInputFile);
            StreamReader secondInput = new StreamReader(secondInputFile);
            StreamWriter output = new StreamWriter(outputFile);
            string input;

            using (output)
            {
                using (firstInput)
                {
                    input = firstInput.ReadToEnd();
                }

                output.Write(input);

                using (secondInput)
                {
                    input = secondInput.ReadToEnd();
                }

                output.Write(input);
            }

            Console.WriteLine("Concatenation finished successfully.");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("The path cannot be empty.");
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