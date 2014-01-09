//Write a program that, depending on the user's choice inputs int, double or string variable. If the variable is integer or double, increases it with 1. If the variable
//is string, appends "*" at its end. The program must show the value of that variable as a console output. Use switch statement.

using System;
using System.Globalization;
using System.Threading;

class UsersChoiceVariableManipulation
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Enter the type of variable you want to change(int, double or string): ");
        string userChoice = Console.ReadLine();

        switch (userChoice)
        {
            case "int":
                Console.Write("Enter your integer number: ");
                int userInputInt = int.Parse(Console.ReadLine());
                Console.WriteLine("Your int after the change is {0}", userInputInt + 1);
                break;
            case "double":
                Console.Write("Enter your real number: ");
                double userInputDouble = double.Parse(Console.ReadLine());
                Console.WriteLine("Your double after the change is {0:0.##}", userInputDouble + 1);
                break;
            case "string":
                Console.Write("Enter your string: ");
                string userInputString = Console.ReadLine();
                Console.WriteLine("Your string after the change is: " + userInputString + "*");
                break;
            default:
                Console.WriteLine("Invalid type!");
                break;
        }
    }
}