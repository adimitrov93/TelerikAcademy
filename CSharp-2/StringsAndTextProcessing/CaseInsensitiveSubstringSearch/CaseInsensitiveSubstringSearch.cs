//Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).

using System;

class CaseInsensitiveSubstringSearch
{
    static int CountStringOccurrences(string str, string pattern)
    {
        int count = 0;
        int i = 0;

        while ((i = str.IndexOf(pattern, i)) != -1)
        {
            i += pattern.Length;
            count++;
        }

        return count;
    }

    static void Main()
    {
        string str = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string pattern = "in";

        str = str.ToLower();
        pattern = pattern.ToLower();

        Console.WriteLine("The result is: {0}", CountStringOccurrences(str, pattern));
    }
}