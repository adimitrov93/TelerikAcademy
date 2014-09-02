// 08. Write a program that reads a string from the console and finds all products that contain this string. Ensure you handle correctly characters like ', %, ", \ and _.

namespace AllProductsContainingString
{
    using System;
    using System.Data.SqlClient;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter pattern: ");
            var pattern = Console.ReadLine();

            Console.WriteLine(FindAllProducts(pattern));
        }

        public static string FindAllProducts(string pattern)
        {
            SqlConnection db = new SqlConnection(Settings.Default.DBConnectionString);
            db.Open();
            var result = new StringBuilder();

            using(db)
            {
                SqlCommand cmdFindAllProducts = new SqlCommand("SELECT ProductName FROM Products WHERE CHARINDEX(@pattern, ProductName) > 0", db);
                cmdFindAllProducts.Parameters.AddWithValue("@pattern", pattern);

                var reader = cmdFindAllProducts.ExecuteReader();

                while (reader.Read())
                {
                    result.AppendLine(reader["ProductName"].ToString());
                }
            }

            return result.ToString();
        }
    }
}
