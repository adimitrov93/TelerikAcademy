//Write a program that finds the maximal sequence of equal elements in an array.
//		Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.

using System;

class SequenceOfEqualElements
{
    static void Main()
    {
        int[] array = { 2, 1, 1, 2, 3, 3, 3, 3, 2, 2, 2, 1 };

        int count = 0, longestSeqCount = 0;
        int element = 0, longestSeqElem = 0;

        foreach (var item in array)
        {
            if (item != element)
            {
                if (count > longestSeqCount)
                {
                    longestSeqCount = count;
                    longestSeqElem = element;
                }
                count = 1;
                element = item;
            }
            else
            {
                count++;
            }
        }

        Console.Write("{");

        for (int i = 0; i < longestSeqCount; i++)
        {
            if (i == (longestSeqCount - 1))
            {
                Console.Write("{0}", longestSeqElem);
            }
            else
            {
                Console.Write("{0}, ", longestSeqElem);
            }
        }

        Console.WriteLine("}");
    }
}