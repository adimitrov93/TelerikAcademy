using System;

class Sheets
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < 11; i++)
        {
            if (((n >> i) & 1) == 0)
            {
                Console.WriteLine("A{0}", 10 - i);
            }
        }
    }
}