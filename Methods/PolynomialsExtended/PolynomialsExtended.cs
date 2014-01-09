//Extend the program to support also subtraction and multiplication of polynomials.

using System;

class PolynomialsExtended
{
    static int[] Addition(int[] a, int[] b)     //Adds two polynomials
    {
        if (a.Length < b.Length)
        {
            int[] temp = a;
            a = b;
            b = temp;
        }

        int[] result = new int[a.Length];

        for (int i = 0; i < b.Length; i++)
        {
            result[i] = a[i] + b[i];
        }

        for (int i = b.Length; i < a.Length; i++)
        {
            result[i] = a[i];
        }

        return result;
    }

    static int[] Substraction(int[] a, int[] b)     //Substract two polynomials a - b
    {
        int[] bMinus = new int[b.Length];

        for (int i = 0; i < b.Length; i++)
        {
            bMinus[i] = -b[i];
        }

        int[] result = Addition(a, bMinus);

        return result;
    }

    static int[] Multiplication(int[] a, int[] b)       //Multiply two polynomials
    {
        int sizeOfResult = a.Length + b.Length - 1;
        int[] result = new int[sizeOfResult];

        for (int i = 0; i < a.Length; i++)
        {
            for (int j = 0; j < b.Length; j++)
            {
                result[i + j] += a[i] * b[j];
            }
        }

        return result;
    }

    static void PrintPolynomial(int[] polynomial)       //Displays one polynomial
    {
        for (int i = polynomial.Length - 1; i >= 0; i--)
        {
            if (i == polynomial.Length - 1)
            {
                if (polynomial[i] > 0)
                {
                    Console.Write(polynomial[i] == 1 ? "x^{1}" : "{0}x^{1}", polynomial[i], i);
                }
                else if (polynomial[i] < 0)
                {
                    Console.Write(polynomial[i] == -1 ? "-x^{1}" : "{0}x^{1}", polynomial[i], i);
                }
            }
            else if (i == 1)
            {
                if (polynomial[i] > 0)
                {
                    Console.Write(polynomial[i] == 1 ? "+x" : "+{0}x", polynomial[i]);
                }
                else if (polynomial[i] < 0)
                {
                    Console.Write(polynomial[i] == 1 ? "-x" : "{0}x", polynomial[i]);
                }
            }
            else if (i == 0)
            {
                if (polynomial[i] > 0)
                {
                    Console.Write("+{0}", polynomial[i]);
                }
                else if (polynomial[i] < 0)
                {
                    Console.Write("{0}", polynomial[i]);
                }
            }
            else if (polynomial[i] > 0)
            {
                Console.Write(polynomial[i] == 1 ? "+x^{1}" : "+{0}x^{1}", polynomial[i], i);
            }
            else if (polynomial[i] < 0)
            {
                Console.Write(polynomial[i] == -1 ? "-x^{1}" : "{0}x^{1}", polynomial[i], i);
            }
        }
    }

    static void PrintOperation(int[] firstPolynomial, int[] secondPolynomial, int[] result, string action)      ///Displays the whole operation Ex: a - b = c, where a, b, c are polynomials
    {
        if (action.Equals("Addition"))
        {
            Console.Write("("); PrintPolynomial(firstPolynomial); Console.Write(") + ("); PrintPolynomial(secondPolynomial); Console.Write(") = ("); PrintPolynomial(result); Console.WriteLine(")");

            Console.WriteLine();
        }
        else if (action.Equals("Substraction"))
        {
            Console.Write("("); PrintPolynomial(firstPolynomial); Console.Write(") - ("); PrintPolynomial(secondPolynomial); Console.Write(") = ("); PrintPolynomial(result); Console.WriteLine(")");

            Console.WriteLine();
        }
        else if (action.Equals("Multiplication"))
        {
            Console.Write("("); PrintPolynomial(firstPolynomial); Console.Write(") * ("); PrintPolynomial(secondPolynomial); Console.Write(") = ("); PrintPolynomial(result); Console.WriteLine(")");

            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Invalid operation!");
        }
    }

    static void Main()
    {
        int[] firstPolynomial = { 1, 1, 1 };
        int[] secondPolynomial = { 1, 1, -1 };

        int[] result = Addition(firstPolynomial, secondPolynomial);

        PrintOperation(firstPolynomial, secondPolynomial, result, "Addition");

        result = Substraction(firstPolynomial, secondPolynomial);

        PrintOperation(firstPolynomial, secondPolynomial, result, "Substraction");

        result = Multiplication(firstPolynomial, secondPolynomial);

        PrintOperation(firstPolynomial, secondPolynomial, result, "Multiplication");
    }
}