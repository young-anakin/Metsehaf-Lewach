using System.ComponentModel.DataAnnotations;

namespace LewachBookTrading.Model
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string? CommentDescription { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public Post? Post { get; set; }
        public int PostId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public User? CommentedBy { get; set; }

        public int CommentedById { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;


    }
}
