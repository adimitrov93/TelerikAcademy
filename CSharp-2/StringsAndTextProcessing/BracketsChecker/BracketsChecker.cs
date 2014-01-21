//Write a program to check if in a given expression the brackets are put correctly.
//Example of correct expression: ((a+b)/5-d).
//Example of incorrect expression: )(a+b)).

using System;

class BracketsChecker
{
    static bool CheckBrackets(string str)
    {
        int brackets = 0;

        for (int i = 0; i < str.Length && brackets >= 0; i++)
        {
            if (str[i] == '(')
            {
                brackets++;
            }
            else
            {
                brackets--;
            }
        }

        return brackets == 0;
    }

    static void Main()
    {
        string str = ")(a+b))";

        Console.WriteLine(CheckBrackets(str));
    }
}