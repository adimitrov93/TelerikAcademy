//Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL]. Sample HTML fragment:

using System;

class HTMLTagReplace
{
    const string oldOpen = "<a href";
    const string oldClose = "</a>";
    const string newOpen = "<URL";
    const string newClose = "</URL>";

    static void Main()
    {
        string htmlFile = "<p>Please visit <a href=\"http://academy.telerik. com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";

        htmlFile = htmlFile.Replace(oldOpen, newOpen);
        htmlFile = htmlFile.Replace(oldClose, newClose);

        Console.WriteLine(htmlFile);
    }
}