using System;

class WeAllLoveBits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];

        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int pTilda;
        int pColon;
        int mask;
        int result;
        bool firstOneFound;
        int firstOnesPosition;


        foreach (var number in numbers)
        {
            pTilda = 0;
            pColon = 0;
            mask = 0;
            result = 0;
            firstOneFound = false;
            firstOnesPosition = 0;

            for (int i = 0; i < 31; i++)
            {
                mask = (1 << (30 - i));

                if (((number & mask) != 0) && !(firstOneFound))
                {
                    firstOneFound = true;
                    firstOnesPosition = (30 - i);
                    break;
                }
            }

            for (int i = 0; i <= firstOnesPosition; i++)
            {
                mask = (1 << i);
                pColon <<= 1;

                if ((number & mask) != 0)
                {
                    pColon |= 1;
                }
            }

            for (int i = 0; i <= firstOnesPosition; i++)
            {
                mask = (1 << i);

                if ((number & mask) != 0)
                {
                    pTilda &= ~(1 << i);
                }
                else
                {
                    pTilda |= (1 << i);
                }
            }

            result = ((number ^ pTilda) & pColon);
            Console.WriteLine(result);
        }
    }
}