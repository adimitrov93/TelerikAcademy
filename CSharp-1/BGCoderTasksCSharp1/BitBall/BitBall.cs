using System;

class BitBall
{
    static void Main()
    {
        byte[] topTeam = new byte[8];
        byte[] bottomTeam = new byte[8];

        for (int i = 0; i < 8; i++)
        {
            topTeam[i] = byte.Parse(Console.ReadLine());
        }

        for (int i = 0; i < 8; i++)
        {
            bottomTeam[i] = byte.Parse(Console.ReadLine());
        }

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (((topTeam[i] & (1 << j)) != 0) && ((bottomTeam[i] & (1 << j)) != 0))
                {
                    topTeam[i] &= (byte)(~(1 << j));
                    bottomTeam[i] &= (byte)(~(1 << j));
                }
            }
        }

        int topTeamScore = 0;
        int bottomTeamScore = 0;
        bool goalPossible = true;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if ((topTeam[i] & (1 << j)) != 0)
                {
                    goalPossible = true;

                    for (int k = (i + 1); k < 8; k++)
                    {
                        if (((bottomTeam[k] & (1 << j)) != 0) || ((topTeam[k] & (1 << j)) != 0))
                        {
                            goalPossible = false;
                        }
                    }

                    if (goalPossible)
                    {
                        topTeamScore++;
                    }
                }
            }
        }

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if ((bottomTeam[i] & (1 << j)) != 0)
                {
                    goalPossible = true;

                    for (int k = (i - 1); k >= 0; k--)
                    {
                        if (((topTeam[k] & (1 << j)) != 0) || ((bottomTeam[k] & (1 << j)) != 0))
                        {
                            goalPossible = false;
                        }
                    }

                    if (goalPossible)
                    {
                        bottomTeamScore++;
                    }
                }
            }
        }

        Console.WriteLine("{0}:{1}", topTeamScore, bottomTeamScore);

    }
}