//Write a program that reads a string, reverses it and prints the result at the console.
//Example: "sample"  "elpmas".

using System;

class ReverseString
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        char[] stringInCharArray = input.ToCharArray();

        Array.Reverse(stringInCharArray);

        string result = new string(stringInCharArray);

        Console.WriteLine("{0} -> {1}", input, result);
    }
}