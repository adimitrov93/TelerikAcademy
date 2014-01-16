//Write a program that reads a list of words from a file words.txt and finds how many times each of the words is contained in another file test.txt.
//The result should be written in the file result.txt and the words should be sorted by the number of their occurrences in descending order. Handle all possible exceptions in your methods.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class WordCounter
{
    const string database = "words.txt";
    const string input = "test.txt";
    const string output = "result.txt";

    static string[] DatabaseReader()
    {
        StreamReader reader = new StreamReader(database);
        string data;

        using (reader)
        {
            data = reader.ReadToEnd();
        }

        data = data.ToLower();
        data = RemoveAllNonAlphabeticCharacters(data);

        string[] words = data.Split('\n');

        return words;
    }
    
    static string RemoveAllNonAlphabeticCharacters(string input)
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            if (Char.IsLetterOrDigit(input[i]) || input[i] == '\n' || input[i] == ' ')
            {
                result.Append(input[i]);
            }
        }

        return result.ToString();
    }

    static void SortArrays(string[] words, int[] count)
    {
        int biggestElem = 0, position = 0;

        for (int i = 0; i < count.Length; i++)
        {
            biggestElem = count[i];
            position = i;

            for (int j = i; j < count.Length; j++)              //Finding the biggest element
            {
                if (count[j] > biggestElem)
                {
                    biggestElem = count[j];
                    position = j;
                }
            }

            if (biggestElem > count[i])
            {
                Swap<int>(ref count[position], ref count[i]);
                Swap<string>(ref words[position], ref words[i]);
            }
        }
    }

    static void Swap<T>(ref T value1, ref T value2)
    {
        T temp = value1;
        value1 = value2;
        value2 = temp;
    }

    static void Main()
    {
        if (!File.Exists(database))
        {
            Console.WriteLine(@"Add file ""words.txt"" in %ProjectFolder%\bin\Debug");
            Environment.Exit(0);
        }

        if (!File.Exists(input))
        {
            Console.WriteLine(@"Add file ""test.txt"" in %ProjectFolder%\bin\Debug");
            Environment.Exit(0);
        }

        string[] words = DatabaseReader();
        int[] count = new int[words.Length];

        try
        {
            StreamReader reader = new StreamReader(input);

            using (reader)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    line = RemoveAllNonAlphabeticCharacters(line);
                    line = line.ToLower();
                    string[] inputWords = line.Split(' ');

                    foreach (var inputWord in inputWords)
                    {
                        for (int i = 0; i < words.Length; i++)
                        {
                            if (inputWord.Equals(words[i]))
                            {
                                count[i]++;
                            }
                        }
                    }

                    line = reader.ReadLine();
                }

                SortArrays(words, count);

                StreamWriter writer = new StreamWriter(output);

                using (writer)
                {
                    for (int i = 0; i < words.Length; i++)
                    {
                        writer.WriteLine("{0} : {1}", words[i], count[i]);
                    }
                }
            }

            Console.WriteLine("Operation finished seccessfully.");
            Console.WriteLine(@"Results saved in ""test.txt"" in %ProjectFolder%\bin\Debug");
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