//Write a method that adds two polynomials. Represent them as arrays of their coefficients as in the example below:
//		x2 + 5 = 1x2 + 0x + 5 

using System;

class PolynomialsAddition
{
    static int[] Addition(int[] a, int[] b)         //Adds two polynomials
    {
        if (a.Length < b.Length)        //Ensure that a is bigger or equal to b
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

    static void PrintPolynomial(int[] polynomial)       //Displays one polynomial
    {
        for (int i = polynomial.Length - 1; i >= 0; i--)
        {
            if (i == polynomial.Length - 1)         //If it is the biggest power of x
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
            else if (i == 1)                //If it is the x to the power of 1. We don't need to display ^1
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
            else if (i == 0)                //If it is the last term - the one without the x
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

    static void PrintAddition(int[] firstPolynomial, int[] secondPolynomial, int[] result)      ///Displays the whole operation a + b = c, where a, b, c are polynomials
    {
        Console.Write("("); PrintPolynomial(firstPolynomial); Console.Write(") + ("); PrintPolynomial(secondPolynomial); Console.Write(") = ("); PrintPolynomial(result); Console.WriteLine(")");

        Console.WriteLine();
    }

    static void Main()
    {
        int[] firstPolynomial = { 5, 1, 2 };
        int[] secondPolynomial = { 8, -1, 5 };

        int[] result = Addition(firstPolynomial, secondPolynomial);

        PrintAddition(firstPolynomial, secondPolynomial, result);
    }
}