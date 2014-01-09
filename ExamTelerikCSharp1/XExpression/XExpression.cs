using System;
using System.Text;

class XExpression
{
    public static decimal deistvie(decimal op1, decimal op2, char op)
    {
        if (op == '+')
        {
            return op1 + op2;
        }
        else if (op == '-')
        {
            return op1 - op2;
        }
        else if (op == '*')
        {
            return op1 * op2;
        }
        else
        {
            return op1 / op2;
        }
    }

    static void Main()
    {
        char input, inputb, op = ';', opb = ';';
        decimal op1 = 0m, op2 = 0m;
        decimal op1b = 0m, op2b = 0m;

        while ((input = (char)Console.Read()) != '=')
        {
            if (input - '0' > 0 && input - '0' <= 9)
            {
                if (op1 == 0)
                {
                    op1 = input - '0';
                }
                else
                {
                    op2 = input - '0';
                }
            }
            else if (input == '(')
            {
                while ((inputb = (char)Console.Read()) != ')')
                {
                    if (inputb - '0' > 0 && inputb - '0' <= 9)
                    {
                        if (op1b == 0)
                        {
                            op1b = inputb - '0';
                        }
                        else
                        {
                            op2b = inputb - '0';
                        }
                    }
                    else if (inputb == '+' || inputb == '-' || inputb == '/' || inputb == '*')
                    {
                        opb = inputb;
                    }

                    if (op1b != 0 && op2b != 0 && (opb == '+' || opb == '-' || opb == '/' || opb == '*'))
                    {
                        op1b = deistvie(op1b, op2b, opb);
                        op2b = 0;
                    }
                }

                if (op1b == 0 && op == '/')
                {
                    Console.WriteLine(op1/op1b);
                    return;
                }
                else if (op == ';')
                {
                    op1 = op1b;
                    op1b = 0;
                    op2b = 0;
                }
                else
                {
                    op2 = op1b;
                    op1b = 0;
                    op2b = 0;
                }
            }
            else if (input == '.')
            {
                int mnojitel = 1;
                input = (char)Console.Read();
                while (input - '0' >= 0 && input - '0' <= 9)
                {
                    if (op1 != 0 && op2 == 0)
                    {
                        op1 += ((decimal)(input - '0') / (10 * mnojitel));
                    }
                    else
                    {
                        op2 += ((decimal)(input - '0') / (10 * mnojitel));
                    }
                    input = (char)Console.Read();
                    mnojitel *= 10;
                }
            }
            
            
            if (input == '+' || input == '-' || input == '/' || input == '*')
            {
                op = input;
            }

            if (op1 != 0 && op2 != 0 && (op == '+' || op == '-' || op == '/' || op == '*'))
            {
                op1 = deistvie(op1, op2, op);
                op2 = 0;
            }
        }

        Console.WriteLine("{0:f2}", op1);
    }
}