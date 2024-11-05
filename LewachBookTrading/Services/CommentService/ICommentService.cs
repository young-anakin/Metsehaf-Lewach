using LewachBookTrading.DTOs.CommentDTO;
using LewachBookTrading.Model;

namespace LewachBookTrading.Services.CommentService
{
    public interface ICommentService
    {
        Task<Comment> AddComment(AddCommentDTO addCommentDTO);
    }
}
