//Write a program that extracts from given XML file all the text without the tags. Example:

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class ExtractTextFromXML
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

    static string[] Extract(string input)
    {
        List<string> words = new List<string>();
        StringBuilder word = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '>')
            {
                if ((i + 1) < input.Length)
                {
                    i++;
                }
                else
                {
                    break;
                }

                while (input[i] != '<')
                {
                    word.Append(input[i]);

                    if ((i + 1) < input.Length)
                    {
                        i++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (word.Length > 0)
                {
                    words.Add(word.ToString());
                    word.Clear();
                }
            }
        }

        return words.ToArray();
    }

    static void Main()
    {
        Console.Write("Enter the path to the XML file: ");
        string input = Console.ReadLine();

        input = AddBackslashes(input);

        try
        {
            StreamReader reader = new StreamReader(input);
            List<string[]> extractedWords = new List<string[]>();

            using (reader)
            {
                string line = reader.ReadLine();

                if (Extract(line).Length > 0)
                {
                    extractedWords.Add(Extract(line));
                }
            }

            foreach (var words in extractedWords)
            {
                foreach (var word in words)
                {
                    Console.WriteLine(word);
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