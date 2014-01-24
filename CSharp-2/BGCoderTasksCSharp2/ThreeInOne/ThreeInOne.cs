//I did't prepare very much for this exam. That's why I don't have many tasks.

using System;
using System.Collections.Generic;

class ThreeInOne
{
    static void Main()
    {
        #region FirstTask
        string firstTaskInput = Console.ReadLine();
        string[] firstTaskTokens = firstTaskInput.Split(',');
        int[] points = new int[firstTaskTokens.Length];

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = int.Parse(firstTaskTokens[i]);
        }

        int resultFirstTask = SolveFirstTask(points);
        #endregion

        #region SecondTask
        string secondTaskInput = Console.ReadLine();
        string[] secondTaskTokens = secondTaskInput.Split(',');
        int[] bytes = new int[secondTaskTokens.Length];

        for (int i = 0; i < bytes.Length; i++)
        {
            bytes[i] = int.Parse(secondTaskTokens[i]);
        }

        int f = int.Parse(Console.ReadLine());
        int resultSecondTask = SolveSecondTask(bytes, f);
        #endregion

        #region ThirdTask
        string thirdTaskInput = Console.ReadLine();
        string[] thirdTaskTokens = thirdTaskInput.Split();
        int[] coins = new int[thirdTaskTokens.Length];

        for (int i = 0; i < coins.Length; i++)
        {
            coins[i] = int.Parse(thirdTaskTokens[i]);
        }

        int resultThirdTask = SolveThirdTask(coins);
        #endregion

        Console.WriteLine(resultFirstTask);
        Console.WriteLine(resultSecondTask);
        Console.WriteLine(resultThirdTask);
    }

    private static int SolveThirdTask(int[] coins)
    {
        int G1 = coins[0];
        int S1 = coins[1];
        int B1 = coins[2];
        int G2 = coins[3];
        int S2 = coins[4];
        int B2 = coins[5];
        bool haveEnought = true;
        int counter = 0;

        while (B1 < B2 || S1 < S2 || G1 < G2)
        {
            if (B1 < B2)
            {
                while (B1 < B2)
                {
                    B1 += 9;
                    S1--;
                    counter++;
                }
            }

            if (G1 < G2)
            {
                while (G1 < G2)
                {
                    G1++;
                    S1 -= 11;
                    counter++;
                }
            }

            if (S1 < S2)
            {
                if (G1 > G2)
                {
                    while (S1 < S2 && G1 >= G2)
                    {
                        S1 += 9;
                        G1--;
                        counter++;
                    }
                }
                else if (S1 < S2)
                {
                    while (S1 < S2)
                    {
                        S1++;
                        B1 -= 11;
                        counter++;
                    }
                }
            }
        }

        return counter;
    }

    private static int SolveSecondTask(int[] input, int f)
    {
        Array.Sort(input);
        Stack<int> bytes = new Stack<int>(input);
        int eatenByMe = 0;
        int nextToEat = 0;

        for (int i = 0; bytes.Count > 0; i++)
        {
            if (nextToEat == i)
            {
                eatenByMe += bytes.Pop();
                nextToEat += (f + 1);
            }
            else
            {
                bytes.Pop();
            }
        }

        return eatenByMe;
    }

    private static int SolveFirstTask(int[] points)
    {
        int winner = 0;
        int winnerPoints = 0;

        for (int i = 0; i < points.Length; i++)
        {
            if (points[i] > 21)
            {
                continue;
            }
            else if (points[i] > winnerPoints)
            {
                winnerPoints = points[i];
                winner = i;
            }
            else if (points[i] == winnerPoints)
            {
                return -1;
            }
        }

        return winner;
    }
}