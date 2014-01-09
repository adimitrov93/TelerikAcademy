/*Write a program that can solve these tasks:
Reverses the digits of a number
Calculates the average of a sequence of integers
Solves a linear equation a * x + b = 0
		Create appropriate methods.
		Provide a simple text-based menu for the user to choose which task to solve.
		Validate the input data:
The decimal number should be non-negative
The sequence should not be empty
a should not be equal to 0*/

using System;
using System.Collections.Generic;

class MathTaskSolver
{
    static void PrintMenu()     //Prints the menu.
    {
        Console.WriteLine("This is a simple math task solver. You can choose between:");
        Console.WriteLine("1. Reverse the digits of a number.");
        Console.WriteLine("2. Calculate the average of a sequence of integers.");
        Console.WriteLine("3. Solve a linear equation a * x + b = 0.");
        Console.Write("Your choice: ");
    }

    static void InputData()     //Takes users choice and call other methods.
    {
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
            {
                int inputNumber = IntInput();

                int reversedNumber = ReverseNumber(inputNumber);

                Console.WriteLine("{0} -> {1}", inputNumber, reversedNumber);

                break;
            }
            case 2:
            {
                int[] inputSequence = SequenceInput();

                double averageOfTheSequence = AverageOfSequence(inputSequence);

                Console.WriteLine("The average of the sequence is {0}", averageOfTheSequence);

                break;
            }
            case 3:
            {
                double[] inputEquation = EquationInput();

                double result = EquationSolver(inputEquation);

                Console.WriteLine("{0} * x + {1} = {2}", inputEquation[0], inputEquation[1], result);

                break;
            }
            default:
            {
                Console.WriteLine("Invalid choice!");

                break;
            }
        }
    }

    static int IntInput()       //Takes one integer from the console and validates it.
    {
        Console.Write("Enter a number to reverse: ");

        int input = int.Parse(Console.ReadLine());

        if (input < 0)
        {
            while (input < 0)
            {
                Console.WriteLine("Invalid number!");
                Console.Write("Enter a number to reverse: ");

                input = int.Parse(Console.ReadLine());
            }
        }

        return input;
    }

    static int ReverseNumber(int number)    //Reverses the parameter
    {
        int reversed = 0;

        while (number > 0)
        {
            reversed = (reversed * 10) + (number % 10);
            number /= 10;
        }

        return reversed;
    }

    static int[] SequenceInput()            //Takes the sequence from the console
    {
        int input;
        List<int> sequence = new List<int>();

        while (true)
        {
            Console.WriteLine("Enter your sequence of integers each on a line. Enter non-integer to stop.");

            Console.Write("Integer: ");

            while (int.TryParse(Console.ReadLine(), out input))
            {
                sequence.Add(input);

                Console.Write("Integer: ");
            }

            if (sequence.Count != 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("You must enter at least 1 integer!");
            }
        }
        
        return sequence.ToArray();
    }

    static double AverageOfSequence(int[] sequence)     //Calculates the average of the sequence
    {
        double average = 0;

        for (int i = 0; i < sequence.Length; i++)
        {
            average += sequence[i];
        }

        average /= sequence.Length;

        return average;
    }

    static double[] EquationInput()         //Takes "a" and "b" from the console
    {
        double input;
        double[] sequenceInput = new double[2];

        Console.WriteLine("a * x + b = 0");

        Console.Write("a = ");
        input = int.Parse(Console.ReadLine());

        if (input == 0)
        {
            while (input == 0)
            {
                Console.WriteLine("Invalid value! \"a\" must be different from 0.");

                Console.Write("a = ");
                input = int.Parse(Console.ReadLine());
            }
        }

        sequenceInput[0] = input;

        Console.Write("b = ");
        input = int.Parse(Console.ReadLine());

        sequenceInput[1] = input;

        return sequenceInput;
    }

    static double EquationSolver(double[] equation)     //Solves the equation
    {
        double a = equation[0];
        double b = equation[1];
        double result;

        result = -b / a;

        return result;
    }

    static void Main()
    {
        PrintMenu();

        InputData();
    }
}
