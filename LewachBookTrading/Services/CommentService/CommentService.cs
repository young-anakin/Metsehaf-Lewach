using LewachBookTrading.Context;
using LewachBookTrading.DTOs.CommentDTO;
using LewachBookTrading.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace LewachBookTrading.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly DataContext _context;

        public CommentService(DataContext context)
        {
            _context = context; 
        }

        public async Task<Comment> AddComment(AddCommentDTO addCommentDTO)
        {
            var comment = new Comment();

            comment.CommentDescription = addCommentDTO.CommentDescription;
            comment.CommentedById = addCommentDTO.CommentedById;
            comment.PostId = addCommentDTO.PostId;

            var commenter = await _context.Users.Where(u => u.Id == addCommentDTO.CommentedById).FirstOrDefaultAsync();
            var post = await _context.Posts.Where(p => p.Id == addCommentDTO.PostId).FirstOrDefaultAsync();

            if (comment == null || post == null)
            {
                return null;
            }
            comment.CommentedBy = commenter;
            comment.Post = post;

            post.Comments.Add(comment);
            commenter.Comments.Add(comment);

            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;

        }

        public async Task<Comment> DeleteComment(int Id)
        {
            var comment = await _context.Comments.Where(c => c.Id == Id).FirstOrDefaultAsync();
            if (comment == null)
            {
                throw (new Exception("No Such Comment"));
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return comment;
        }
    }
}
