namespace ForumSystem.Models
{
    using System.Collections.Generic;

    public class Group
    {
        private ICollection<User> users;

        public Group()
        {
            this.users = new HashSet<User>();
        }

        public int GroupId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
