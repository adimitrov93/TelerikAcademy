//I did't prepare very much for this exam. That's why I don't have many tasks.

using System;
using System.Collections.Generic;

class JoroTheRabbit
{
    static int?[] nullableTerrain;

    static int[] FindPossibleSteps(int position)
    {
        List<int> possibleSteps = new List<int>();

        for (int i = 0; i < nullableTerrain.Length; i++)
        {
            if (nullableTerrain[position] < nullableTerrain[i])
            {
                possibleSteps.Add(Math.Abs(position - i));
            }
        }

        return possibleSteps.ToArray();
    }

    static void Main()
    {
        string input = Console.ReadLine();
        string[] inputFragments = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        int[] terrain = new int[inputFragments.Length];

        for (int i = 0; i < inputFragments.Length; i++)
        {
            terrain[i] = int.Parse(inputFragments[i]);
        }

        int bestRouteLenght = 0;
        nullableTerrain = new int?[terrain.Length];

        for (int i = 0; i < terrain.Length; i++)
        {
            nullableTerrain[i] = terrain[i];
        }

        for (int i = 0; i < terrain.Length; i++)
        {
            int position = i;
            int[] steps = FindPossibleSteps(position);

            foreach (var step in steps)
            {
                int?[] curTerrain = (int?[])nullableTerrain.Clone();
                int? previousEl = curTerrain[i];
                curTerrain[i] = null;
                int currentLenght = 1;

                while (true)
                {
                    position += step;

                    if (position > curTerrain.Length - 1)
                    {
                        position -= curTerrain.Length;
                    }

                    if (curTerrain[position] > previousEl && curTerrain[position].HasValue)
                    {
                        currentLenght++;
                        previousEl = curTerrain[position];
                        curTerrain[position] = null;
                    }
                    else
                    {
                        break;
                    }
                }

                if (currentLenght > bestRouteLenght)
                {
                    bestRouteLenght = currentLenght;
                }
            }
        }

        Console.WriteLine(bestRouteLenght);
    }
}
