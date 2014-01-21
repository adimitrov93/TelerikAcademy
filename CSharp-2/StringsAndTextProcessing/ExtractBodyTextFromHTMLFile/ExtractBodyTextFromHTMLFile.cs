//Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags. Example:

using System;
using System.Text.RegularExpressions;

class ExtractBodyTextFromHTMLFile
{
    const string titlePattern = "<title>.*title>";
    const string bodyPattern = @"<body>[\s\S\n]*body>";
    const string tagPattern = "<.*>";

    static void Main()
    {
        string file = @"<html>
  <head><title>News</title></head>
  <body><p><a href=""http://academy.telerik.com"">Telerik
    Academy</a>aims to provide free real-world practical
    training for young people who want to turn into
    skillful .NET software engineers.</p></body>
</html>";

        Regex regex = new Regex(titlePattern);

        if (regex.IsMatch(file))
        {
            var titleMatch = regex.Match(file);
            string title = titleMatch.Value;
            title = title.Substring(7, title.Length - 15);

            Console.WriteLine("Title: {0}", title);
        }
        
        regex = new Regex(bodyPattern);

        var bodyMatch = regex.Match(file);
        string body = bodyMatch.Value;

        regex = new Regex(tagPattern);

        body = regex.Replace(body, " ");

        Console.WriteLine("Body: {0}", body);
    }
}