using LewachBookTrading.Context;
using LewachBookTrading.DTOs.BookDTO;
using LewachBookTrading.DTOs.PostDTO;
using LewachBookTrading.Model;
using Microsoft.EntityFrameworkCore;

namespace LewachBookTrading.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly DataContext _context;

        public PostService(DataContext context)
        {
            _context = context;

        }

        public async Task<Post> AddPost(AddPostDTO addPostDTO)
        {
            var post = new Post();
            var poster = await _context.Users.Include(u => u.Posts).FirstOrDefaultAsync(u => u.Id == addPostDTO.PostedById);
            if (poster == null)
            {
                return null;
            }
            //var poster = await _context.Users.FirstOrDefaultAsync(u => u.Id == addPostDTO.PostedById);

            post.Title = addPostDTO.Title;
            post.Description = addPostDTO.Description;
            post.Location = addPostDTO.Location;
            post.Photos = addPostDTO.Photos?.Select(photo => photo.Title).ToList();
            post.PostedById = addPostDTO.PostedById;
            post.PostedBy = poster;
            poster.Posts.Add(post);

            
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();

            return post;
        }

        public async Task<List<Post>> GetAllPosts()
        {
            var posts = await _context.Posts.Include(p => p.Likes).Include(p => p.Comments)
                .ToListAsync();

            return posts;

        }

        public async Task<Post> GetPostById(int Id)
        {
            var post = await _context.Posts.Where(p => p.Id == Id).Include(p => p.Likes).Include(p => p.Comments)
                .FirstOrDefaultAsync();
            if (post == null)
            {
                throw new Exception("Post not found");

            }
            return post;

        }

        public async Task<Post> UpdatePost(UpdatePostDTO updatePostDTO)
        {
            var post = await _context.Posts.Where(p => p.Id == updatePostDTO.Id).FirstOrDefaultAsync();
            if (post == null)
            {
                throw new Exception("Post not found");

            }

            post.Location = updatePostDTO.Location;
            post.Photos = updatePostDTO.Photos.Select(photo => photo.Title).ToList(); 
            post.Title = updatePostDTO.Title;
            post.Description = updatePostDTO.Description;

            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
            
            return post;

        }

        public async Task<Post> DeletePost(int Id)
        {
            var post = await _context.Posts.Where(p => p.Id == Id).FirstOrDefaultAsync();
            if (post == null)
            {
                return null;
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return post;
        }

        public async Task<List<Post>> GetPostOfSpecificUser(int Id)
        {
            var posts = await _context.Posts.Where(p => p.PostedById == Id).Include(p => p.Likes).Include(p => p.Comments).ToListAsync();

            return posts;
        }


    }
}
