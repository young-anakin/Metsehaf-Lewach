using System.ComponentModel.DataAnnotations;

namespace LewachBookTrading.Model
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string? Description { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public User? PostedBy { get; set; }


        public int? PostedById { get; set; }
        public string? Title { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public string? Location { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        
        public List<string>? Photos { get; set; }

        public ICollection<Like> Likes { get; set; } = new List<Like>();


    }
}
