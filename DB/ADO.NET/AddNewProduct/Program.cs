// 04. Write a method that adds a new product in the products table in the Northwind database. Use a parameterized SQL command.

namespace AddNewProduct
{
    using System;
    using System.Data.SqlClient;

    public class Program
    {
        public static void Main()
        {
            var isAdded = AddNewProduct("Kebapche", 6, "10 v tarelka", 4, false);

            if (isAdded)
            {
                Console.WriteLine("Product added!");
            }
            else
            {
                Console.WriteLine("Product not added!");
            }
        }

        private static bool AddNewProduct(string name, int categoryId, string quantityPerUnit, decimal unitPrice, bool isDiscontinued)
        {
            bool isAdded = false;
            SqlConnection dbConnection = new SqlConnection(Settings.Default.DBConnectionString);
            dbConnection.Open();

            using (dbConnection)
            {
                SqlCommand cmdInsertNewProduct = new SqlCommand("INSERT INTO Products(ProductName, CategoryID, QuantityPerUnit, UnitPrice, Discontinued) " +
                                                             "VALUES (@name, @categoryId, @quantityPerUnit, @unitPrice, @discontinued)", dbConnection);
                cmdInsertNewProduct.Parameters.AddWithValue("@name", name);
                cmdInsertNewProduct.Parameters.AddWithValue("@categoryId", categoryId);
                cmdInsertNewProduct.Parameters.AddWithValue("@quantityPerUnit", quantityPerUnit);
                cmdInsertNewProduct.Parameters.AddWithValue("@unitPrice", unitPrice);
                cmdInsertNewProduct.Parameters.AddWithValue("@discontinued", isDiscontinued);

                cmdInsertNewProduct.ExecuteNonQuery();

                isAdded = true;
            }

            return isAdded;
        }
    }
}
