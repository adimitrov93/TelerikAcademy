//Declare two string variables and assign them with following value: "The "use" of quotations causes difficulties." Do the above in two different ways: with and without
//using quoted strings.

using System;

class QuotationsMethods
{
    static void Main()
    {
        string a = "The \"use\" of quotations causes difficulties.";
        string b = @"The ""use"" of quotations causes difficulties.";
    }
}