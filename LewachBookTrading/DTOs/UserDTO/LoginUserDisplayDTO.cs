using LewachBookTrading.Model;

namespace LewachBookTrading.DTOs.UserDTO
{
    public class LoginUserDisplayDTO
    {

        //[Required]
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? UserName { get; set; }

        public string? Photo { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int AddressID { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string? Country { get; set; }

        public string? City { get; set; }

        public string? Region { get; set; }

        public string? SubCity { get; set; }

        public string? PostalCode { get; set; }

        public string? StreetAddress { get; set; }
        public string Token { get; set; } = string.Empty;

    }
}
