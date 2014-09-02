// 02. Write a program that retrieves the name and description of all categories in the Northwind DB.

namespace NameAndDescriptionOfAllCategories
{
    using System;
    using System.Data.SqlClient;

    public class Program
    {
        public static void Main()
        {
            SqlConnection dbConnection = new SqlConnection("Server=.; Database=Northwind; Integrated Security=true");
            dbConnection.Open();

            using (dbConnection)
            {
                SqlCommand cmdCategories = new SqlCommand("SELECT CategoryName, Description FROM Categories", dbConnection);
                SqlDataReader reader = cmdCategories.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["CategoryName"];
                        string description = (string)reader["Description"];

                        Console.WriteLine("{0} - {1}", name, description);
                    }
                }
            }
        }
    }
}
