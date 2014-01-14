/* *Write a program that calculates the value of given arithmetical expression. The expression can contain the following elements only:
Real numbers, e.g. 5, 18.33, 3.14159, 12.6
Arithmetic operators: +, -, *, / (standard priorities)
Mathematical functions: ln(x), sqrt(x), pow(x,y)
Brackets (for changing the default priorities)
	Examples:
	(3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7)  ~ 10.6
	pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3)  ~ 21.22
	Hint: Use the classical "shunting yard" algorithm and "reverse Polish notation".*/

using System;
using System.Collections.Generic;
using System.Text;

class ExpressionEvaluation
{
    static string RemoveEmptySpaces(string someString)
    {
        for (int i = 0; i < someString.Length; i++)
        {
            if (someString[i] == ' ')
            {
                someString = someString.Remove(i, 1);
            }
        }

        return someString;
    }

    static string AddEmptySpaces(string someString)
    {
        StringBuilder builder = new StringBuilder(someString);

        for (int i = 0; i < builder.Length; i++)
        {
            if (IsOperator(builder[i]))
            {
                builder.Insert(i + 1, ' ');
                i++;
            }
            else if (Char.IsDigit(builder[i]))
            {
                try
                {
                    while (Char.IsDigit(builder[i]) || builder[i] == '.')
                    {
                        i++;
                    }

                    builder.Insert(i, ' ');
                }
                catch (IndexOutOfRangeException)
                {
                }
            }
            else if (builder[i] == ',')
            {
                builder.Remove(i, 1);
                i--;
            }
            else if (builder[i] == 'l' && builder[i + 1] == 'n')
            {
                builder.Insert(i + 2, ' ');
                i += 2;
            }
            else if (builder[i] == 'p' && builder[i + 1] == 'o' && builder[i + 2] == 'w')
            {
                builder.Insert(i + 3, ' ');
                i += 3;
            }
            else if (builder[i] == 's' && builder[i + 1] == 'q' && builder[i + 2] == 'r' && builder[i + 3] == 't')
            {
                builder.Insert(i + 4, ' ');
                i += 4;
            }
        }

        return builder.ToString();
    }

    static bool IsOperator(char character)
    {
        bool isOperator;

        if (character == '+' || character == '-' || character == '*' || character == '/' || character == '(' || character == ')')
        {
            isOperator = true;
        }
        else
        {
            isOperator = false;
        }

        return isOperator;
    }

    static bool IsOperator(string token)
    {
        bool isOperator;

        if (token == "+" || token == "-" || token == "*" || token == "/" || token == "(" || token == ")")
        {
            isOperator = true;
        }
        else
        {
            isOperator = false;
        }

        return isOperator;
    }

    static bool IsFunction(string token)
    {
        bool IsFunction;

        if (token == "ln" || token == "pow" || token == "sqrt")
        {
            IsFunction = true;
        }
        else
        {
            IsFunction = false;
        }

        return IsFunction;
    }

    static double EvaluateFunction(string[] tokens, ref int position)
    {
        double result = 0;

        if (tokens[position] == "ln")
        {
            result = Math.Log(double.Parse(tokens[position + 2]), Math.E);
            position += 4;
        }
        else if (tokens[position] == "pow")
        {
            result = Math.Pow(double.Parse(tokens[position + 2]), double.Parse(tokens[position + 3]));
            position += 5;
        }
        else if (tokens[position] == "sqrt")
        {
            result = Math.Sqrt(double.Parse(tokens[position + 2]));
            position += 4;
        }
        else
        {
            Console.WriteLine("Invalid expression.");
            Environment.Exit(0);
        }

        return result;
    }

    static void PutIntoStackOrQueue(string token, Queue<string> queue, Stack<string> stack)
    {
        if (token == "+")
        {
            if (stack.Count != 0)
            {
                if (stack.Peek() == "*" || stack.Peek() == "/" || stack.Peek() == "+" || stack.Peek() == "-")
                {
                    while (stack.Peek() == "*" || stack.Peek() == "/" || stack.Peek() == "+" || stack.Peek() == "-")
                    {
                        queue.Enqueue(stack.Pop());

                        if (stack.Count == 0)
                        {
                            break;
                        }
                    }
                }
            }

            stack.Push(token);
        }
        else if (token == "-")
        {
            if (stack.Count != 0)
            {
                if (stack.Peek() == "*" || stack.Peek() == "/" || stack.Peek() == "+" || stack.Peek() == "-")
                {
                    while (stack.Peek() == "*" || stack.Peek() == "/" || stack.Peek() == "+" || stack.Peek() == "-")
                    {
                        queue.Enqueue(stack.Pop());

                        if (stack.Count == 0)
                        {
                            break;
                        }
                    }
                }
            }

            stack.Push(token);
        }
        else if (token == "*")
        {
            if (stack.Count != 0)
            {
                if (stack.Peek() == "*" || stack.Peek() == "/")
                {
                    while (stack.Peek() == "*" || stack.Peek() == "/")
                    {
                        queue.Enqueue(stack.Pop());

                        if (stack.Count == 0)
                        {
                            break;
                        }
                    }
                }
            }

            stack.Push(token);
        }
        else if (token == "/")
        {
            if (stack.Count != 0)
            {
                if (stack.Peek() == "*" || stack.Peek() == "/")
                {
                    while (stack.Peek() == "*" || stack.Peek() == "/")
                    {
                        queue.Enqueue(stack.Pop());

                        if (stack.Count == 0)
                        {
                            break;
                        }
                    }
                }
            }

            stack.Push(token);
        }
        else if (token == "(")
        {
            stack.Push(token);
        }
        else if (token == ")")
        {
            while (stack.Peek() != "(")
            {
                queue.Enqueue(stack.Pop());
            }

            stack.Pop();        //removes left bracket
        }
    }

    static double EvaluateExpression(Queue<string> queue)
    {
        string token;
        Stack<double> stackOfNumbers = new Stack<double>();

        while (queue.Count > 0)
        {
            token = queue.Dequeue();

            if (token.Equals(""))
            {
            }
            else if (!IsOperator(token))
            {
                stackOfNumbers.Push(double.Parse(token));
            }
            else
            {
                if (token == "*")
                {
                    double op2 = stackOfNumbers.Pop();
                    double op1 = stackOfNumbers.Pop();
                    stackOfNumbers.Push(op1 * op2);
                }
                else if (token == "/")
                {
                    double op2 = stackOfNumbers.Pop();
                    double op1 = stackOfNumbers.Pop();

                    if (op2 == 0)
                    {
                        Console.WriteLine("Division by zero is not allowed!");
                        Environment.Exit(0);
                    }
                    else
                    {
                        stackOfNumbers.Push(op1 / op2);
                    }
                }
                else if (token == "+")
                {
                    double op2 = stackOfNumbers.Pop();
                    double op1 = stackOfNumbers.Pop();
                    stackOfNumbers.Push(op1 + op2);
                }
                else if (token == "-")
                {
                    double op2 = stackOfNumbers.Pop();
                    double op1 = stackOfNumbers.Pop();
                    stackOfNumbers.Push(op1 - op2);
                }
            }

            //if (stackOfNumbers.Count == 1 && queue.Count == 0)
            //{
            //    Console.WriteLine("Result = {0}", stackOfNumbers.Pop());
            //    Environment.Exit(0);
            //}
        }

        return stackOfNumbers.Pop();
    }

    static Queue<string> InfixToRPN(string[] tokens)
    {
        Queue<string> queue = new Queue<string>();
        Stack<string> stack = new Stack<string>();

        for (int i = 0; i < tokens.Length; i++)
        {
            if (IsOperator(tokens[i]))
            {
                PutIntoStackOrQueue(tokens[i], queue, stack);
            }
            else if (IsFunction(tokens[i]))
            {
                queue.Enqueue(EvaluateFunction(tokens, ref i).ToString());
            }
            else
            {
                queue.Enqueue(tokens[i]);
            }
        }

        foreach (var operatorInStack in stack)      //Empty the stack
        {
            queue.Enqueue(operatorInStack);
        }

        return queue;
    }

    static void Main()
    {
        string input = Console.ReadLine();

        input = RemoveEmptySpaces(input);

        input = AddEmptySpaces(input);

        string[] tokens = input.Split(' ');

        Queue<string> rpn = InfixToRPN(tokens);

        double result = EvaluateExpression(rpn);

        Console.WriteLine(result);
    }
}