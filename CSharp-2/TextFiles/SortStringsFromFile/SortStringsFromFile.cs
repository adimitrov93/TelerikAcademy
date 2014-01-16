//Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file. Example:
//	Ivan			George
//	Peter			Ivan
//	Maria			Maria
//	George			Peter

using System;
using System.IO;
using System.Text;

class SortStringsFromFile
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

        Console.Write("Enter the path to the output file: ");
        string output = Console.ReadLine();

        input = AddBackslashes(input);
        output = AddBackslashes(output);

        try
        {
            StreamReader reader = new StreamReader(input);
            StreamWriter writer = new StreamWriter(output);
            string data;

            using (reader)
            {
                data = reader.ReadToEnd();
            }

            string[] arrayOfStrings = data.Split('\n');

            Array.Sort(arrayOfStrings);

            using (writer)
            {
                foreach (var item in arrayOfStrings)
                {
                    writer.WriteLine(item);
                }
            }

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