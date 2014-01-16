//Write a program that compares two text files line by line and prints the number of lines that are the same and the number of lines that are different. Assume the files have equal number of lines.

using System;
using System.IO;
using System.Text;

class CompareTextFiles
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
        Console.Write("Enter a path to file for compare: ");
        string firstFile = Console.ReadLine();

        Console.Write("Enter a path to another file for compare: ");
        string secondFile = Console.ReadLine();

        firstFile = AddBackslashes(firstFile);
        secondFile = AddBackslashes(secondFile);

        try
        {
            StreamReader firstInput = new StreamReader(firstFile);
            StreamReader secondInput = new StreamReader(secondFile);
            int equalLines = 0, differentLines = 0;

            using (firstInput)
            {
                using (secondInput)
                {
                    string firstInputLine = firstInput.ReadLine();
                    string secondInputLine = secondInput.ReadLine();

                    while (firstInputLine != null)
                    {
                        if (firstInputLine.Equals(secondInputLine))
                        {
                            equalLines++;
                        }
                        else
                        {
                            differentLines++;
                        }

                        firstInputLine = firstInput.ReadLine();
                        secondInputLine = secondInput.ReadLine();
                    }
                }
            }

            Console.WriteLine("The operation finished successfully.");
            Console.WriteLine("The files have {0} equal lines and {1} different lines.", equalLines, differentLines);
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