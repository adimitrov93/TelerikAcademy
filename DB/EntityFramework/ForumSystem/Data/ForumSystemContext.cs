namespace ForumSystem.Data
{
    using System.Data.Entity;

    using ForumSystem.Models;

    public class ForumSystemContext : DbContext
    {
        public ForumSystemContext()
            : base(Settings.Default.DBConnectionStr)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Group> Groups { get; set; }

    }
}
