using LewachBookTrading.Model;

namespace LewachBookTrading.DTOs.FriendDTO
{
    public class DisplayUserDTO
    {
        public UserDTO user { get; set; }
        public List<FriendDTO> Friends { get; set; }
    }

    public class FriendDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string UserName { get; set; }

        public string Photo {  get; set; }
    }

    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Photo { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string SubCity { get; set; }
        public string PostalCode { get; set; }
        public string StreetAddress { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
