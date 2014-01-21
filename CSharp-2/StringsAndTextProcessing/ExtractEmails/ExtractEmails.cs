//Write a program for extracting all email addresses from given text. All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails.

using System;
using System.Text.RegularExpressions;

class ExtractEmails
{
    const string pattern = "([a-zA-Z0-9._]*[@][a-zA-Z0-9]*[.][a-zA-Z]*)";
    static void Main()
    {
        string text = "You can contact Telerik Academy Team at academy@telerik.com";

        Regex regex = new Regex(pattern);

        MatchCollection emails = regex.Matches(text);

        foreach (var email in emails)
        {
            Console.WriteLine(email);
        }
    }
}