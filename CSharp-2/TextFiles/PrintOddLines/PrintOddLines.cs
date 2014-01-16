//Write a program that reads a text file and prints on the console its odd lines.

using System;
using System.IO;
using System.Text;

class PrintOddLines
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
        Console.Write("Enter the full path to the file: ");
        string path = Console.ReadLine();

        path = AddBackslashes(path);

        try
        {
            StreamReader streamReader = new StreamReader(path);

            using (streamReader)
            {
                int lineNumber = 0;
                string line = streamReader.ReadLine();

                while (line != null)
                {
                    lineNumber++;

                    if (lineNumber % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }

                    line = streamReader.ReadLine();
                }
            }
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