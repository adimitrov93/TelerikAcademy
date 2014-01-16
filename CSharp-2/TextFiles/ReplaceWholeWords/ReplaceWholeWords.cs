//Modify the solution of the previous problem to replace only whole words (not substrings).

using System;
using System.IO;
using System.Text;

class ReplaceWholeWords
{
    const string tempFilename = "temp.txt";

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
        Console.Write("Enter the path to the file: ");
        string input = Console.ReadLine();

        input = AddBackslashes(input);

        try
        {
            StreamReader reader = new StreamReader(input);
            StreamWriter writer = new StreamWriter(tempFilename);

            using (reader)
            {
                using (writer)
                {
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        line = line.Replace(" start ", " finish ");     //The only change from the previous task.

                        writer.WriteLine(line);

                        line = reader.ReadLine();
                    }
                }
            }

            reader = new StreamReader(tempFilename);
            writer = new StreamWriter(input);

            using (reader)
            {
                using (writer)
                {
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        writer.WriteLine(line);

                        line = reader.ReadLine();
                    }
                }
            }

            File.Delete(tempFilename);

            Console.WriteLine("Operation finished seccessfully.");
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