//*Write a program to read your age from the console and print how old you will be after 10 years.

using System;

class MyAgeAfter10Years
{
    static void Main()
    {
        Console.Write("Enter your age: ");
        byte age = byte.Parse(Console.ReadLine());
        Console.WriteLine("After 10 years you will be {0} years old.", age + 10);
    }
}