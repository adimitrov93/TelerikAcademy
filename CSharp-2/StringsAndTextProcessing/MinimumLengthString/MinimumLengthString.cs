//Write a program that reads from the console a string of maximum 20 characters. If the length of the string is less than 20, the rest of the characters should be filled with '*'. Print the result string into the console.

using System;

class MinimumLengthString
{
    static void Main()
    {
        Console.Write("Enter string with maximum length of 20 characters: ");
        string str = Console.ReadLine();

        if (str.Length == 20)
        {
            Console.WriteLine(str);
        }
        else if (str.Length > 20)
        {
            str = str.Substring(0, 20);

            Console.WriteLine(str);
        }
        else
        {
            Console.WriteLine(str + new string('*', 20 - str.Length));
        }
    }
}