//Write a program that finds the maximal increasing sequence in an array. Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.

using System;

class SequenceOfIcreasingElements
{
    static void Main()
    {
        int[] array = { 3, 2, 3, 4, 2, 2, 4 };

        int startElement = 0, lastElement = 0;
        int longestSeqCount = 0, count = 0;
        int longestSeqStartElem = 0, longestSeqLastElem = 0;

        foreach (var item in array)
        {
            if (item == (lastElement + 1))
            {
                count++;
                lastElement = item;
            }
            else
            {
                if (count > longestSeqCount)
                {
                    longestSeqCount = count;
                    longestSeqStartElem = startElement;
                    longestSeqLastElem = lastElement;
                }
                count = 1;
                startElement = item;
                lastElement = item;
            }
        }

        Console.Write("{");

        for (int i = 0; i < longestSeqCount; i++)
        {
            if (i == (longestSeqCount - 1))
            {
                Console.Write("{0}", longestSeqLastElem);
            }
            else
            {
                Console.Write("{0}, ", longestSeqStartElem + i);
            }
        }

        Console.WriteLine("}");
    }
}