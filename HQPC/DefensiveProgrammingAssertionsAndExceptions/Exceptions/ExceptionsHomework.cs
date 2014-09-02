using System;
using System.Collections.Generic;
using System.Text;

public class ExceptionsHomework
{
    public static void Main()
    {
        var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(string.Join(" ", subarr));

        var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(string.Join(" ", allarr));

        var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(string.Join(" ", emptyarr));

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));
        //// I comment this because it throws exception. The quadra / is not a mistake. It's done like this because it's comment out of the line of code. Make it double and run StyleCop for more information.
        //// Console.WriteLine(ExtractEnding("Hi", 100));

        int numberToCheckForPrime = 23;

        if (IsPrime(numberToCheckForPrime))
        {
            Console.WriteLine("{0} is prime.", numberToCheckForPrime);
        }
        else
        {
            Console.WriteLine("{0} is not prime.", numberToCheckForPrime);
        }

        numberToCheckForPrime = 33;

        if (IsPrime(numberToCheckForPrime))
        {
            Console.WriteLine("{0} is prime.", numberToCheckForPrime);
        }
        else
        {
            Console.WriteLine("{0} is not prime.", numberToCheckForPrime);
        }

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }

    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (arr == null)
        {
            throw new ArgumentNullException("arr", "The array cannot be null.");
        }

        if (startIndex < 0 || startIndex >= arr.Length)
        {
            throw new ArgumentOutOfRangeException("startIndex", string.Format("Start index must be between 0 and {0} inclusively", arr.Length));
        }

        if (startIndex + count > arr.Length)
        {
            throw new ArgumentOutOfRangeException("count", string.Format("Start index + count must be less than array's length. In this case count < {0}", arr.Length - startIndex - 1));
        }

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (count > str.Length)
        {
            throw new ArgumentOutOfRangeException("count", "Count must be less than string's length.");
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static bool IsPrime(int number)
    {
        bool isPrime = true;
        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                isPrime = false;

                break;
            }
        }

        return isPrime;
    }
}
