using LewachBookTrading.DTOs.PostDTO;
using LewachBookTrading.Model;

namespace LewachBookTrading.Services.PostService
{
    public interface IPostService
    {
        Task<Post> AddPost(AddPostDTO addPostDTO);
        Task<Post> DeletePost(int Id);
        Task<List<Post>> GetAllPosts();
        Task<Post> GetPostById(int Id);
        Task<List<Post>> GetPostOfSpecificUser(int Id);
        Task<Post> UpdatePost(UpdatePostDTO updatePostDTO);
    }
}