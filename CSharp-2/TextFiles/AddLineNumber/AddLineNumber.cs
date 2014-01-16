//Write a program that reads a text file and inserts line numbers in front of each of its lines. The result should be written to another text file.

using System;
using System.IO;
using System.Text;

class AddLineNumber
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
        Console.Write("Enter the path to the input file: ");
        string input = Console.ReadLine();

        Console.Write("Enter the path for the output file: ");
        string output = Console.ReadLine();

        input = AddBackslashes(input);
        output = AddBackslashes(output);

        try
        {
            StreamReader reader = new StreamReader(input);
            StreamWriter writer = new StreamWriter(output);

            using (reader)
            {
                using (writer)
                {
                    int lineNumber = 0;

                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        lineNumber++;

                        writer.WriteLine("Line {0}: {1}", lineNumber, line);

                        line = reader.ReadLine();
                    }
                }
            }

            Console.WriteLine("Operation ended successfully.");
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