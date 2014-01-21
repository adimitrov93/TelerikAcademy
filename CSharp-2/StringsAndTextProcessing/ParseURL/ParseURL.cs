//Write a program that parses an URL address given in the format: and extracts from it the [protocol], [server] and [resource] elements. 
//For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted: [protocol] = "http" [server] = "www.devbg.org" [resource] = "/forum/index.php"

using System;
using System.Text.RegularExpressions;

class ParseURL
{
    const string patternProtocol = "[a-zA-Z]*://";
    const string patternServer = "//[a-zA-Z.-]*/";
    const string patternResource = "[a-zA-Z]/[a-zA-Z0-9./]*";

    static void Main()
    {
        Console.Write("Enter URL: ");
        string input = Console.ReadLine();

        Regex regexProtocol = new Regex(patternProtocol);
        Regex regexServer = new Regex(patternServer);
        Regex regexResource = new Regex(patternResource);

        var matchProtocol = regexProtocol.Match(input);
        var matchServer = regexServer.Match(input);
        var matchResource = regexResource.Match(input);

        string protocol = matchProtocol.Value;
        string server = matchServer.Value;
        string resource = matchResource.Value;

        protocol = protocol.Substring(0, protocol.Length - 3);
        server = server.Substring(2, server.Length - 3);
        resource = resource.Substring(1, resource.Length - 1);

        Console.WriteLine("[protocol] = \"{0}\"", protocol);
        Console.WriteLine("[server] = \"{0}\"", server);
        Console.WriteLine("[resource] = \"{0}\"", resource);
    }
}