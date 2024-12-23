﻿using System.ComponentModel.DataAnnotations;

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

        public string? Country { get; set; }

        public string? City { get; set; }

        public string? Region { get; set; }

        public string? SubCity { get; set; }

        public string? PostalCode { get; set; }

        public string? StreetAddress { get; set; }

        //public int AddressID { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Like> Likes { get; set; } = new List<Like>();

        public List<JournalTags>? JournalTags { get; set; }

        public List<Journal>? Journals { get; set; }
        //[System.Text.Json.Serialization.JsonIgnore]


        public int RoleId { get; set; }

        public Role? Role { get; set; }

        public ICollection<UserFriend> Friends { get; set; } = new List<UserFriend>();
    }
}
