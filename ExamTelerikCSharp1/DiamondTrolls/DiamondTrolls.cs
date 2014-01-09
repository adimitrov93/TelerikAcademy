using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int height = (6 + ((n - 3) / 2) * 3);
        int width = n * 2 + 1;
        int dotCount = (width - 3);
        int firstDots = dotCount / 4;
        int secondDots = dotCount / 4;

        for (int i = 0; i < height; i++)
        {
            if (i == 0)
            {
                Console.WriteLine(new String('.', (width - n) / 2) + new String('*', n) + new String('.', (width - n) / 2));
            }
            else if (i == (height - n - 1))
            {
                Console.WriteLine(new String('*', width));
            }
            else if (i == height - 1)
            {
                Console.WriteLine(new String('.', (width - 1) / 2) + '*' + new String('.', (width - 1) / 2));
            }
            else if (i < (height - n - 1))
            {
                Console.WriteLine(new String('.', firstDots) + '*' + new String('.', secondDots) + '*' + new String('.', secondDots) + '*' + new String('.', firstDots));

                if (i < (height - n - 2))
                {
                    firstDots--;
                    secondDots++;
                }
            }
            else
            {
                Console.WriteLine(new String('.', firstDots) + '*' + new String('.', secondDots) + '*' + new String('.', secondDots) + '*' + new String('.', firstDots));
                firstDots++;
                secondDots--;
            }

        }
    }
}