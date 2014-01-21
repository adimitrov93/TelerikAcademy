//Write a program that reverses the words in given sentence.
//	Example: "C# is not C++, not PHP and not Delphi!"  "Delphi not and PHP, not C++ not is C#!".

using System;
using System.Collections.Generic;
using System.Text;

class ReverseWordsInASentence
{
    public struct pMark         //Keep the punct marks in the sentence. Position means after witch word the mark appears.
    {
        public char symbol;
        public int position;
    };      

    static string SearchForPMarks(string str, Queue<pMark> queue)           //Searches for marks, enqueue them and remove them from the sentece.
    {
        int spaces = 0;

        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == ',' || str[i] == '-' || str[i] == '!' || str[i] == '?' || str[i] == '.')
            {
                pMark mark = new pMark();
                mark.symbol = str[i];
                mark.position = spaces + 1;     //spaces + 1 gives us after witch word are we
                queue.Enqueue(mark);
                str = str.Remove(i, 1);
                i--;
            }
            else if (str[i] == ' ')
            {
                spaces++;
            }
        }

        return str;
    }

    static void Main()
    {
        Queue<pMark> pMarks = new Queue<pMark>();
        string sentence = "C# is not C++, not PHP and not Delphi!";

        sentence = SearchForPMarks(sentence, pMarks);

        string[] words = sentence.Split(' ');

        Array.Reverse(words);
        StringBuilder newSentence = new StringBuilder();
        int spaces = 0;
        pMark currentPMark = pMarks.Dequeue();

        foreach (var word in words)
        {
            newSentence.Append(word);

            if (currentPMark.position == spaces + 1)
            {
                newSentence.Append(currentPMark.symbol);

                if (pMarks.Count != 0)
                {
                    currentPMark = pMarks.Dequeue();
                }
            }

            newSentence.Append(" ");
            spaces++;
        }

        Console.WriteLine(newSentence);
    }
}