using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

class BunnyFactory
{
    static Queue<int> ConcatAndRemoveOnesAndZeros(Queue<int> cages, BigInteger sum, BigInteger product)
    {
        Queue<int> newCages = new Queue<int>();
        StringBuilder concat = new StringBuilder();
        StringBuilder result = new StringBuilder();

        concat.AppendFormat("{0}{1}", sum, product);

        int uslovie = cages.Count;
        for (int i = 0; i < uslovie; i++)
        {
            concat.Append(cages.Dequeue());
        }

        for (int i = 0; i < concat.Length; i++)
        {
            if (concat[i] != '0' && concat[i] != '1')
            {
                newCages.Enqueue(concat[i] - '0');
            }
        }

        return newCages;
    }

    static void Main()
    {
        Queue<int> cages = new Queue<int>();

        while (true)
        {
            string input = Console.ReadLine();

            if (input.Equals("END"))
            {
                break;
            }

            cages.Enqueue(int.Parse(input));
        }

        string result = MultiplicationProcess(cages);

        result = result.Trim();

        Console.WriteLine(result);
    }

    private static string MultiplicationProcess(Queue<int> cages)
    {
        StringBuilder result = new StringBuilder();
        BigInteger s = 0, sum = 0, product = 1;

        for (int i = 0; ; i++)
        {
            result.Clear();
            s = 0;
            sum = 0;
            product = 1;

            if (cages.Count < i)
            {
                int uslovie = cages.Count;
                for (int j = 0; j < uslovie; j++)
                {
                    result.AppendFormat("{0} ", cages.Dequeue());
                }

                return result.ToString();
            }

            try
            {
                for (int j = 0; j <= i; j++)
                {
                    s += cages.Peek();
                    result.AppendFormat("{0} ", cages.Dequeue());
                }
            }
            catch (InvalidOperationException)
            {
            }

            if (s > cages.Count)
            {
                int uslovie = cages.Count;
                for (int j = 0; j < uslovie; j++)
                {
                    result.AppendFormat("{0} ", cages.Dequeue());
                }

                return result.ToString();
            }

            for (int j = 0; j < s; j++)
            {
                sum += cages.Peek();
                product *= cages.Dequeue();
            }

            cages = ConcatAndRemoveOnesAndZeros(cages, sum, product);
        }
    }
}