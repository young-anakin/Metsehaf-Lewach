using System.ComponentModel.DataAnnotations;

namespace LewachBookTrading.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        //[Required]
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? UserName { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public string? Photo { get; set; }

        public string? PhoneNumber { get; set; }
        
        public DateTime? DateOfBirth { get; set; }

        public Address? Address { get; set; }

        public int AddressID { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
