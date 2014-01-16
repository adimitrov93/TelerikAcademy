//Write a program that removes from a text file all words listed in given another text file. Handle all possible exceptions in your methods.

using System;
using System.IO;
using System.Text;

class RemoveWords
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

    static string[] DatabaseReader(string path)
    {
        StreamReader reader = new StreamReader(path);
        string database = null;

        using (reader)
        {
            database = reader.ReadToEnd();
        }

        if (database.Length == 0)
        {
            Console.WriteLine("Database cannot be empty.");
            Environment.Exit(0);
        }

        return database.Split(' ', '\n', ',', ';', '.', '\t');
    }

    static void Main()
    {
        Console.Write("Enter the path to the file: ");
        string input = Console.ReadLine();

        Console.Write("Enter the path to the database: ");
        string database = Console.ReadLine();

        input = AddBackslashes(input);
        database = AddBackslashes(database);

        string[] wordsToRemove = DatabaseReader(database);

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
                        foreach (var word in wordsToRemove)
                        {
                            line = line.Replace(word, String.Empty);
                        }

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