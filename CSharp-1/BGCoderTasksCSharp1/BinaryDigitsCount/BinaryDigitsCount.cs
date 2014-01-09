using System;

class BinaryDigitsCount
{
    static void Main(string[] args)
    {
        int b = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        uint[] array = new uint[n];

        for (int i = 0; i < n; i++)
        {
            array[i] = uint.Parse(Console.ReadLine());
        }

        int onesCount, zerosCount, lastOneDigit;
        for (int i = 0; i < n; i++)
        {
            onesCount = 0;
            zerosCount = 0;
            lastOneDigit = 0;
            for (int j = 0; j < 32; j++)
            {
                uint mask = 1u << j;
                if ((array[i] & mask) == 0)
                {
                    zerosCount++;
                }
                else
                {
                    onesCount++;
                    lastOneDigit = j;
                }
            }

            if (b == 1)
            {
                Console.WriteLine(onesCount);
            }
            else
            {
                Console.WriteLine(lastOneDigit - onesCount + 1);
            }
        }
    }
}