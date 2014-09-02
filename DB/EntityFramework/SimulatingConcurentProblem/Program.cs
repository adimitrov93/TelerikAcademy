namespace SimulatingConcurentProblem
{
    using System;

    using NorthwindTasks;

    public class Program
    {
        public static void Main()
        {
            var db = new NorthwindEntities();
            using (db)
            {
                var scope = db.Database.BeginTransaction();
                using (scope)
                {
                    try
                    {
                        var invalidOrder = new Order();
                        invalidOrder.CustomerID = "SOOOINVALID";

                        db.Orders.Add(invalidOrder);

                        var validOrder = new Order();
                        validOrder.CustomerID = "VINET";

                        db.Orders.Add(validOrder);

                        db.SaveChanges();
                        scope.Commit();
                    }
                    catch (Exception)
                    {
                        scope.Rollback();
                    }
                }
            }
        }
    }
}
