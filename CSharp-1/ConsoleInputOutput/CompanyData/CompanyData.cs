//A company has name, address, phone number, fax number, web site and manager. The manager has first name, last name, age and a phone number. Write a program that reads
//the information about a company and its manager and prints them on the console.

using System;

class CompanyData
{
    static void Main()
    {
        Console.Write("Enter company's name: ");
        string companysName = Console.ReadLine();

        Console.Write("Enter company's adress: ");
        string companysAdress = Console.ReadLine();

        Console.Write("Enter company's phone number: ");
        ulong companysPhoneNumber = ulong.Parse(Console.ReadLine());

        Console.Write("Enter company's fax number: ");
        ulong companysFaxNumber = ulong.Parse(Console.ReadLine());

        Console.Write("Enter company's web site: ");
        string companysWebSite = Console.ReadLine();

        Console.Write("Enter manager's first name: ");
        string managersFirstName = Console.ReadLine();

        Console.Write("Enter manager's last name: ");
        string managersLastName = Console.ReadLine();

        Console.Write("Enter manager's age: ");
        byte managersAge = byte.Parse(Console.ReadLine());

        Console.Write("Enter manager's phone number: ");
        ulong managersPhoneNumber = ulong.Parse(Console.ReadLine());

        Console.Clear();

        Console.WriteLine("\t\t\t\tCompany's info.");
        Console.Write(new string ('-', 80));
        Console.WriteLine("Name: {0}", companysName);
        Console.WriteLine("Adress: {0}", companysAdress);
        Console.WriteLine("Phone number: {0:0### ### ###}", companysPhoneNumber);
        Console.WriteLine("Fax number: {0:0### ### ###}", companysFaxNumber);
        Console.WriteLine("Web site: {0}", companysWebSite);
        Console.WriteLine();

        Console.WriteLine("\t\t\t\tManager's info.");
        Console.Write(new string('-', 80));
        Console.WriteLine("Name: {0} {1}", managersFirstName, managersLastName);
        Console.WriteLine("Age: {0}", managersAge);
        Console.WriteLine("Phone number: {0:0### ### ###}", managersPhoneNumber);
        Console.WriteLine();
    }
}