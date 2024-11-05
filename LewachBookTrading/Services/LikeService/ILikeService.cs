using LewachBookTrading.DTOs.LikeDTO;
using LewachBookTrading.Model;

namespace LewachBookTrading.Services.LikeService
{
    public interface ILikeService
    {
        Task<Like> AddLike(AddLikeDTO addLikeDTO);
        Task<Like> RemoveLike(AddLikeDTO addLikeDTO);
    }
}
