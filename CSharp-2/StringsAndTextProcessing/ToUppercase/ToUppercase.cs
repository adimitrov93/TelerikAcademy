//You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested. Example:

using System;
using System.Text;

class ToUppercase
{
    const string openTag = "<upcase>";
    const string closeTag = "</upcase>";

    static string Upcase(string str)
    {
        StringBuilder result = new StringBuilder();
        int startPosition = 0, endPosition = 0;

        while ((endPosition = str.IndexOf(openTag, endPosition)) != -1)
        {
            result.Append(str.Substring(startPosition, endPosition - startPosition));
            startPosition = endPosition + openTag.Length;
            endPosition = str.IndexOf(closeTag, endPosition);
            result.Append(str.Substring(startPosition, endPosition - startPosition).ToUpper());
            startPosition = endPosition + closeTag.Length;
        }

        result.Append(str.Substring(startPosition));

        return result.ToString();
    }

    static void Main()
    {
        string str = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        string result = Upcase(str);

        Console.WriteLine(result);
    }
}