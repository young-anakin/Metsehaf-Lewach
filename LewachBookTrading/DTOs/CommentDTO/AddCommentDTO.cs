using LewachBookTrading.Model;

namespace LewachBookTrading.DTOs.CommentDTO
{
    public class AddCommentDTO
    {
        public string? CommentDescription { get; set; }
        public int PostId { get; set; }
        public int CommentedById { get; set; }
    }
}
