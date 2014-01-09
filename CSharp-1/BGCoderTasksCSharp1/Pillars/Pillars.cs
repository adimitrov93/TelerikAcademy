using System;

class Pillars
{
    static void Main()
    {
        byte[] numbers = new byte[8];
        int sum = 0;

        for (int i = 0; i < 8; i++)
        {
            numbers[i] = byte.Parse(Console.ReadLine());
            sum += numbers[i];
        }

        int pillarPosition;
        int leftCount;
        int rightCount;
        int mask;

        for (int i = 0; i < 8; i++)
        {
            pillarPosition = (7 - i);
            leftCount = 0;
            rightCount = 0;

            foreach (var number in numbers)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (j != pillarPosition)
                    {
                        mask = (1 << j);

                        if (((number & mask) != 0) && (j < pillarPosition))
                        {
                            rightCount++;
                        }
                        else if (((number & mask) != 0) && (j > pillarPosition))
                        {
                            leftCount++;
                        }
                    }
                }
            }

            if (leftCount == rightCount)
            {
                if (sum == 0)
                {
                    pillarPosition = 7;
                }
                Console.WriteLine(pillarPosition);
                Console.WriteLine(leftCount);
                return;
            }
        }

        Console.WriteLine("No");
    }
}