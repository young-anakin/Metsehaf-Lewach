using LewachBookTrading.DTOs.FriendDTO;

namespace LewachBookTrading.Services.FriendService
{
    public interface IFriendService
    {
        Task<bool> AddFriendship(AddFriendDTO DTO);
    }
}