namespace CategoriesAndProducts
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
                SqlCommand cmdCategories = new SqlCommand("SELECT [c].[CategoryName], [p].[ProductName]" +
                                                              "FROM [Northwind].[dbo].[Categories] AS [c]" +
                                                              "JOIN [Northwind].[dbo].[Products] AS [p]" +
                                                          "ON [c].[CategoryID] = [p].[CategoryID]" +
                                                          "ORDER BY [c].[CategoryName]", dbConnection);
                SqlDataReader reader = cmdCategories.ExecuteReader();
                using (reader)
                {

                    Console.WriteLine(new string('-', 60));
                    Console.WriteLine("| {0, -18}{1, -38 } |", "Category", "| Product");
                    Console.WriteLine(new string('-', 60));

                    while (reader.Read())
                    {
                        string category = (string)reader["CategoryName"];
                        string product = (string)reader["ProductName"];

                        Console.WriteLine("| {0, -18}{1, -38} |", category, "| " + product);
                    }

                    Console.WriteLine(new string('-', 60));
                }
            }
        }
    }
}
