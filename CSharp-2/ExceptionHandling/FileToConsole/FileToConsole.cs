//Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console.
//Find in MSDN how to use System.IO.File.ReadAllText(…). Be sure to catch all possible exceptions and print user-friendly error messages.

using System;
using System.Text;
using System.IO;

class FileToConsole
{
    static string AddBackslashes(string inputString)
    {
        StringBuilder inputStringBuider = new StringBuilder(inputString);

        for (int i = 0; i < inputStringBuider.Length; i++)
        {
            if (inputStringBuider[i] == '\\')
            {
                inputStringBuider.Insert(i + 1, '\\');
                i++;
            }
        }

        return inputStringBuider.ToString();
    }

    static void Main()
    {
        Console.Write("Enter file path: ");
        string path = Console.ReadLine();

        path = AddBackslashes(path);

        try
        {
            string file = File.ReadAllText(path);

            Console.WriteLine(file);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("The path is empty.");
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("The path, filename or both are too long.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Invalid path.");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("Path is in an invalid format.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("This file is read-only or you don't have permissions to open it.");
        }
        catch (IOException)
        {
            Console.WriteLine("File cannot be open.");
        }
    }
}