using System.ComponentModel.DataAnnotations;

namespace LewachBookTrading.Model
{
    public class Like
    {
        [Key]
        public int Id { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public User? LikedBy { get; set; }
        public int LikerId { get; set; }

        public DateTime LikedAt { get; set; } = DateTime.Now;

        public int? PostId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Post? Post { get; set; }
    }
}
