using LewachBookTrading.DTOs.FriendDTO;

namespace LewachBookTrading.Services.FriendService
{
    public interface IFriendService
    {
        Task<String> AcceptFriendRequest(int requestId);
        Task<String> AddFriendship(AddFriendDTO DTO);
        Task<String> DeclineFriendRequest(int requestId);
        Task<List<FriendRequest>> GetPendingRequests(int userId);
        Task<FriendRequest> RemoveFriendRequest(int requestId, int sender);
        Task<String> SendFriendRequest(int senderId, int receiverId);
        Task<string> Unfriend(int userId, int FriendId);
    }
}