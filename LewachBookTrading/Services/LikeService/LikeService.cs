using LewachBookTrading.Context;
using LewachBookTrading.DTOs.LikeDTO;
using LewachBookTrading.Model;
using Microsoft.EntityFrameworkCore;

namespace LewachBookTrading.Services.LikeService
{
    public class LikeService : ILikeService
    {
        private readonly DataContext _context;

        public LikeService(DataContext context)
        {
            _context = context;
        }

        public async Task<Like> AddLike(AddLikeDTO addLikeDTO)
        {
            if (!await _context.Likes.AnyAsync(l => l.PostId == addLikeDTO.PostId && l.LikerId == addLikeDTO.LikerId))
            {
                var like = new Like();
                like.LikerId = addLikeDTO.LikerId;
                like.PostId = addLikeDTO.PostId;
                var user = _context.Users.FirstOrDefault(x => x.Id == like.LikerId);
                var post = _context.Posts.FirstOrDefault(x => x.Id == like.PostId);
                
                if (user != null && post != null)
                {
                    like.LikedBy = user;
                    like.Post = post;
                    user.Likes.Add(like);
                    post.Likes.Add(like);

                    _context.Likes.Add(like);
                    await _context.SaveChangesAsync();

                    return like;
                }
                return null;

            }

            return null;
                
        }

        public async Task<Like> RemoveLike(AddLikeDTO addLikeDTO)
        {
            var like = await _context.Likes.FirstOrDefaultAsync(l => l.PostId == addLikeDTO.PostId && l.LikerId == addLikeDTO.LikerId);
            if (like != null)
            {
                _context.Likes.Remove(like);
                await _context.SaveChangesAsync();
                return like;
            }

            return null;
        }

    }
}
