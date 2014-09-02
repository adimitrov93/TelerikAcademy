namespace ForumSystem
{
    using System;
    using System.Linq;

    using ForumSystem.Data;
    using ForumSystem.Models;

    public class Program
    {
        public static void Main()
        {
            var db = new ForumSystemContext();
            Console.WriteLine(db.Database.CreateIfNotExists());


            using (db)
            {
                var tran = db.Database.BeginTransaction();
                using (tran)
                {
                    try
                    {
                        var user = new User();
                        user.Nickname = "hackera";

                        db.Users.Add(user);

                        var adminGroup = db.Groups.FirstOrDefault(g => g.Name == "Admin");

                        if (adminGroup == null)
                        {
                            adminGroup = new Group();
                            adminGroup.Name = "Admin";
                            db.Groups.Add(adminGroup);
                        }

                        user.Group = adminGroup;
                        db.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("213");
                        tran.Rollback();
                    }
                }


                Console.WriteLine(db.Users.Count());
                Console.WriteLine(db.Groups.Count());
            }
        }
    }
}
