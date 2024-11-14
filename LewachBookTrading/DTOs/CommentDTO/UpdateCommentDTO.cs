using LewachBookTrading.Model;

namespace LewachBookTrading.DTOs.CommentDTO
{
    public class UpdateCommentDTO
    {
        public int Id { get; set; }
        public string? CommentDescription { get; set; }

        //[System.Text.Json.Serialization.JsonIgnore]
        //public Post? Post { get; set; }
        public int PostId { get; set; }

        //[System.Text.Json.Serialization.JsonIgnore]
        //public User? CommentedBy { get; set; }

        public int CommentedById { get; set; }

    }
}
