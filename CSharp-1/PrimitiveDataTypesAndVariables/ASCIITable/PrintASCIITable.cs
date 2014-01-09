//Find online more information about ASCII (American Standard Code for Information Interchange) and write a program that prints the entire ASCII table of characters on
//the console.

using System;
using System.Text;

class PrintASCIITable
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;

        char ch;
        for (int i = 0; i <= 255; i++)
        {
            ch = (char)i;
            Console.WriteLine(ch);
        }
    }
}