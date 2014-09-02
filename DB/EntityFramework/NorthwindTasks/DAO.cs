namespace NorthwindTasks
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;
    using System.Linq;

    public static class DAO
    {
        // 02. Create a DAO class with static methods which provide functionality for inserting, modifying and deleting customers. Write a testing class.
        public static void InsertCustomer(Customer newCustomer)
        {
            var db = new NorthwindEntities();

            using (db)
            {
                db.Customers.Add(newCustomer);
                db.SaveChanges();
            }
        }

        public static void ModifyCustomerCompanyName(string customerId, string newCompanyName)
        {
            var db = new NorthwindEntities();

            using (db)
            {
                var customer = db.Customers.Find(customerId);
                customer.CompanyName = newCompanyName;
                db.SaveChanges();
            }
        }

        public static Customer DeleteCustomer(string customerId)
        {
            var db = new NorthwindEntities();
            Customer customerToRemove = null;

            using (db)
            {
                customerToRemove = db.Customers.Find(customerId);

                if (customerToRemove != null)
                {
                    db.Customers.Remove(customerToRemove);
                    db.SaveChanges();
                }
            }

            return customerToRemove;
        }

        // 03. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
        public static List<Customer> FindAllCustomersWithOrdersIn1997AndShippedToCanada()
        {
            var db = new NorthwindEntities();

            using (db)
            {
                return db.Customers.Where(c => c.Orders.Any(o => o.OrderDate.Value.Year == 1997 && o.ShipCountry == "Canada")).ToList();
            }
        }

        // 04. Implement previous by using native SQL query and executing it through the DbContext.
        public static List<string> FindAllCustomersWithOrdersIn1997AndShippedToCanadaWithNativeSQL()
        {
            var db = new NorthwindEntities();

            using (db)
            {
                //db.Customers.Where(c => c.Orders.Any(o => o.OrderDate.Value.Year == 1997 && o.ShipCountry == "Canada")).ToList();
                return db.Database.SqlQuery<string>("SELECT DISTINCT [c].[CompanyName]" +
                                                    "FROM [Customers] [c]" +
                                                        "JOIN [Orders] [o]" +
                                                        "ON [c].[CustomerID] = [o].[CustomerID]" +
                                                    "WHERE year([o].[OrderDate]) = 1997 AND [o].[ShipCountry] = 'Canada'").ToList();
            }
        }

        // 05. Write a method that finds all the sales by specified region and period (start / end dates).
        public static List<Order> GetOrdersByRegionAndPeriod(string region, DateTime? startDate, DateTime? endDate)
        {
            var db = new NorthwindEntities();

            using (db)
            {
                return db.Orders.Where(o => o.ShipRegion == region && (startDate != null ? o.OrderDate >= startDate : true) && (endDate != null ? o.OrderDate <= endDate : true)).ToList();
            }
        }

        // 06. Create a database called NorthwindTwin with the same structure as Northwind using the features from DbContext. Find for the API for schema generation in MSDN or in Google.
        public static void CloneDb()
        {
            string importDatabaseSchemaScript = (new NorthwindEntities() as IObjectContextAdapter).ObjectContext.CreateDatabaseScript();
            string createDatabaseScript = "CREATE DATABASE NorthwindTwin";
            SqlConnection createDbConnection = new SqlConnection(@"Server=.; Database=master; Integrated Security=true");
            createDbConnection.Open();
            using (createDbConnection)
            {
                SqlCommand createDbCommand = new SqlCommand(createDatabaseScript, createDbConnection);
                createDbCommand.ExecuteNonQuery();
            }

            SqlConnection importDbSchemaConnection = new SqlConnection(@"Server=.; Database=NorthwindTwin; Integrated Security=true");
            importDbSchemaConnection.Open();
            using (importDbSchemaConnection)
            {
                SqlCommand importDbSchemaCommand = new SqlCommand(importDatabaseSchemaScript, importDbSchemaConnection);
                importDbSchemaCommand.ExecuteNonQuery();
            }
        }
    }
}
