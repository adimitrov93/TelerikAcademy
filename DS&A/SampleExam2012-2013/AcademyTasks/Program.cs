using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyTasks
{
    class Program
    {
        static int[] pleasantness;
        static int variety;
        // static int min = int.MaxValue;
        // static int max = int.MinValue;
        static int result = 0;
        static int bestResult = int.MaxValue;

        private static void HandleInput()
        {
            string pleasantnessAsString = Console.ReadLine();
            string[] pleasantnessAsStringArray = pleasantnessAsString.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            pleasantness = new int[pleasantnessAsStringArray.Length];

            for (int i = 0; i < pleasantnessAsStringArray.Length; i++)
            {
                pleasantness[i] = int.Parse(pleasantnessAsStringArray[i]);
            }

            variety = int.Parse(Console.ReadLine());
        }

        static void CanSkipTasks(int index, int min = int.MaxValue, int max = int.MinValue)
        {
            if (index >= pleasantness.Length)
            {
                return;
            }

            result++;

            if (pleasantness[index] < min)
            {
                min = pleasantness[index];
            }

            if (pleasantness[index] > max)
            {
                max = pleasantness[index];
            }

            if (max - min >= variety)
            {
                if (result < bestResult)
                {
                    bestResult = result;
                }
            }

            CanSkipTasks(index + 2, min, max);
            // result--;

            CanSkipTasks(index + 1, min, max);
            result--;
        }

        static int Solver()
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            int minIndex = 0;
            int maxIndex = 0;

            for (int i = 0; i < pleasantness.Length; i++)
            {
                if (pleasantness[i] < min)
                {
                    min = pleasantness[i];
                    minIndex = i;
                }

                if (pleasantness[i] > max)
                {
                    max = pleasantness[i];
                    maxIndex = i;
                }

                //if (pleasantness[i] - pleasantness[0] >= variety || pleasantness[0] - pleasantness[i] >= variety)
                if (max - min >= variety)
                {
                    //return (i / 2) + (i % 2) + 1;
                    //return (minIndex / 2 + minIndex % 2) + (maxIndex / 2 + maxIndex % 2) + 1;

                    if (minIndex % 2 == 1 || maxIndex % 2 == 1)
                    {
                        int leftIndex = Math.Min(minIndex, maxIndex);

                        return (leftIndex / 2 + leftIndex % 2) + Math.Abs(minIndex - maxIndex) / 2 + Math.Abs(minIndex - maxIndex) % 2 + 1;
                    }
                    else
                    {
                        return (i / 2) + (i % 2) + 1;
                    }
                }
            }

            return pleasantness.Length;
        }

        static void Main(string[] args)
        {
            HandleInput();

            //if (pleasantness.Max() - pleasantness.Min() < variety)
            //{
            //    Console.WriteLine(pleasantness.Length);
            //}
            //else
            //{
            //    CanSkipTasks(0);
            //    if (bestResult != 0)
            //    {
            //        Console.WriteLine(bestResult);
            //    }
            //    else
            //    {
            //        Console.WriteLine(pleasantness.Length);
            //    }
            //}

            if (pleasantness.Length == 1)
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(Solver());
            }
        }
    }
}
