using System;
using System;

class MissCat2011
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int cat;
        int[] votes = new int[10];

        for (int i = 0; i < n; i++)
        {
            cat = int.Parse(Console.ReadLine());
            if (cat == 1)
            {
                votes[0]++;
            }
            else if (cat == 2)
            {
                votes[1]++;
            }
            else if (cat == 3)
            {
                votes[2]++;
            }
            else if (cat == 4)
            {
                votes[3]++;
            }
            else if (cat == 5)
            {
                votes[4]++;
            }
            else if (cat == 6)
            {
                votes[5]++;
            }
            else if (cat == 7)
            {
                votes[6]++;
            }
            else if (cat == 8)
            {
                votes[7]++;
            }
            else if (cat == 9)
            {
                votes[8]++;
            }
            else if (cat == 10)
            {
                votes[9]++;
            }
        }

        int maxVotes = 0, winner = 0;

        for (int i = 0; i < 10; i++)
        {
            if (votes[i] > maxVotes)
            {
                maxVotes = votes[i];
                winner = i + 1;
            }
        }

        Console.WriteLine(winner);
    }
}