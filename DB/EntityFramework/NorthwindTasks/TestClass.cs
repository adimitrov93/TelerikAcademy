namespace NorthwindTasks
{
    using System;

    public class TestClass
    {
        public static void Main()
        {
            // 02. Create a DAO class with static methods which provide functionality for inserting, modifying and deleting customers. Write a testing class.
            //DAO.InsertCustomer(new Customer
            //    {
            //        CustomerID = "PESHO",
            //        CompanyName = "Pesho & Gosho Comp."
            //    });

            //DAO.ModifyCustomerCompanyName("PESHO", "Pesho & Gosho Ltd.");

            //DAO.DeleteCustomer("PESHO");

            // 03. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
            //var customers = DAO.FindAllCustomersWithOrdersIn1997AndShippedToCanada();
            //foreach (var customer in customers)
            //{
            //    Console.WriteLine(customer.CompanyName);
            //}

            // 04. Implement previous by using native SQL query and executing it through the DbContext.
            //var customers = DAO.FindAllCustomersWithOrdersIn1997AndShippedToCanadaWithNativeSQL();
            //foreach (var customer in customers)
            //{
            //    Console.WriteLine(customer);
            //}

            // 05. Write a method that finds all the sales by specified region and period (start / end dates).
            //var orders = DAO.GetOrdersByRegionAndPeriod("SP", new DateTime(1996, 10, 12), new DateTime(1998, 2, 25));
            //foreach (var order in orders)
            //{
            //    Console.WriteLine(new string('-', 50));

            //    Console.WriteLine("CustomerID: {0}", order.CustomerID);
            //    Console.WriteLine("ShipName: {0}", order.ShipName);
            //    Console.WriteLine("OrderDate: {0}", order.OrderDate);

            //    Console.WriteLine(new string('-', 50));
            //}

            // 06.Create a database called NorthwindTwin with the same structure as Northwind using the features from DbContext. Find for the API for schema generation in MSDN or in Google.
            //DAO.CloneDb();
        }
    }
}
