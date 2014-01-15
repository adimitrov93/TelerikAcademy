//Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg) and stores it the current directory. Find in Google how to download files in C#.
//Be sure to catch all exceptions and to free any used resources in the finally block.

using System;
using System.IO;
using System.Net;

class DownloadFile
{
    const char urlSeparator = '/';

    static void Main()
    {
        WebClient webClient = new WebClient();

        //Taking URL
        Console.Write("Enter URL of file: ");
        string url = Console.ReadLine();

        string[] partsOfTheURL = url.Split(urlSeparator);       //Needed to take the filename

        try
        {
            //Download
            webClient.DownloadFile(url, partsOfTheURL[partsOfTheURL.Length - 1]);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("The URL cannot be empty.");
        }
        catch (WebException)
        {
            Console.WriteLine("The file not exist or wrong name.");
        }
        finally
        {
            //Free resources
            webClient.Dispose();
        }
    }
}