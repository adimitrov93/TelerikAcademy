namespace ForumSystem.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        public int UserId { get; set; }

        public string Nickname { get; set; }

        [ForeignKey("Group")]
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }
    }
}
