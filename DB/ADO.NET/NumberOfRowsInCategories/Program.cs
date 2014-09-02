// 01. Write a program that retrieves from the Northwind sample database in MS SQL Server the number of rows in the Categories table.

namespace NumberOfRowsInCategories
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
                SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM Categories", dbConnection);
                int numberOfRows = (int)cmdCount.ExecuteScalar();
                Console.WriteLine("Number of rows: {0} ", numberOfRows);
                Console.WriteLine();
            }
        }
    }
}
