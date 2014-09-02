namespace StudentSystem.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class ContactInfo
    {
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}