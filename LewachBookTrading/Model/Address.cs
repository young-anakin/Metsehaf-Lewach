using System.ComponentModel.DataAnnotations;

namespace LewachBookTrading.Model
{
    public class Address
    {
        [Key]
        public int Id { get; set; } // Changed to property

        public string? Country { get; set; }

        public string? City { get; set; }

        public string? Region { get; set; }

        public string? SubCity { get; set; }

        public string? PostalCode { get; set; }

        public string? StreetAddress { get; set; }

        public int UserId { get; set; } // Foreign key for User

        public User? User { get; set; } // Navigation property
    }
}
