using DentalClinic.Services.Tools;
using LewachBookTrading.Context;
using LewachBookTrading.DTOs.FriendDTO;
using LewachBookTrading.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LewachBookTrading.Services.FriendService
{
    public class FriendService : IFriendService
    {
        private readonly DataContext _context;
        private readonly IToolsService _toolsService;

        public FriendService(DataContext context, IToolsService toolsService)
        {
            _context = context;
            _toolsService = toolsService;

        }

        public async Task<String> AddFriendship(AddFriendDTO DTO)
        {
            if (DTO.UserId == DTO.FriendId)
            {
                throw new Exception("Can't be friends with self.");
            }

            var existingFriendship = await _context.UserFriends
                                    .AnyAsync(uf =>
                                        (uf.UserId == DTO.UserId && uf.FriendId == DTO.FriendId) ||
                                        (uf.UserId == DTO.FriendId && uf.FriendId == DTO.UserId)
                                    );

            if (existingFriendship)
            {
                throw new Exception("Friendship already exists.");
            }

            var userFriend = new UserFriend
            {
                UserId = DTO.UserId,
                FriendId = DTO.FriendId
            };

            var reciprocalFriendship = new UserFriend
            {
                UserId = DTO.FriendId,
                FriendId = DTO.UserId
            };

            await _context.UserFriends.AddAsync(userFriend);
            await _context.UserFriends.AddAsync(reciprocalFriendship);

            await _context.SaveChangesAsync();

            return "Friends";
        }

        public async Task<String> SendFriendRequest(int senderId, int receiverId)
        {
            // Check if a request already exists
            var existingRequest = await _context.FriendRequests
                .AnyAsync(fr => fr.SenderId == senderId && fr.ReceiverId == receiverId && !fr.IsAccepted && !fr.IsDeclined);

            if (existingRequest)
            {
                throw new Exception("Request already exists.");
            }

            var frienship = await _context.UserFriends.AnyAsync(fr => fr.FriendId == senderId && fr.UserId == receiverId);

            if (frienship)
            {
                throw new Exception("Friendship already exists");
            }

            var friendRequest = new FriendRequest
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                CreatedAt = DateTime.UtcNow,
                IsAccepted = false,
                IsDeclined = false
            };

            var sender = await _context.Users.FirstOrDefaultAsync(u => u.Id == senderId);
            var receiver = await _context.Users.FirstOrDefaultAsync(u => u.Id == receiverId);

            friendRequest.Sender = sender;
            friendRequest.Receiver = receiver;


            _context.FriendRequests.Add(friendRequest);
            await _context.SaveChangesAsync();
            return "Friend request sent";
        }

        public async Task<String> AcceptFriendRequest(int requestId)
        {
            var request = await _context.FriendRequests.FindAsync(requestId);

            if (request == null || request.IsAccepted || request.IsDeclined)
            {
                throw new Exception( "Friend request not found or it has already been processed"); // Request not found or already processed
            }

            AddFriendDTO afDTO = new AddFriendDTO();
            afDTO.FriendId = request.ReceiverId;
            afDTO.UserId = request.SenderId;

            //AddFriendship(afDTO);

            request.IsAccepted = true; // Mark as accepted
            await _context.SaveChangesAsync();
            return "Friend request accepted";
        }

        public async Task<string> Unfriend(int userId, int FriendId)
        {
            var request = await _context.FriendRequests
                            .Where(u => (u.SenderId == userId && u.ReceiverId == FriendId) || (u.SenderId == FriendId && u.ReceiverId == userId))
                            .FirstOrDefaultAsync();

            if (request == null)
            {
                throw new Exception("Friendship not found.");
            }
            _context.FriendRequests.Remove(request);

            var friendshipA = await _context.UserFriends
                                            .Where(uf => uf.UserId == userId && uf.FriendId == FriendId)
                                            .FirstOrDefaultAsync();
            var friendshipB = await _context.UserFriends
                                            .Where(uf => uf.UserId == FriendId && uf.FriendId == userId)
                                            .FirstOrDefaultAsync();
            if (friendshipA == null || friendshipB == null)
            {

                    // Handle the case where the role is not found
                    throw new Exception("Friendship not found.");
            }
            _context.UserFriends.Remove(friendshipA);
            _context.UserFriends.Remove(friendshipB);

            await _context.SaveChangesAsync();
            return "Unfriended";
        }

        //public async Task<List<User>> GetFriendsOfUser(int id)
        //{
        //    var friends = _context.FriendRequests
        //}

        public async Task<FriendRequest> RemoveFriendRequest(int requestId, int sender)
        {
            var request = await _context.FriendRequests.FindAsync(requestId);

            
            if (request == null || sender != request.SenderId)
            {
                if (request == null)
                {
                    // Handle the case where the role is not found
                    throw new Exception("request not found.");
                }
            }

            _context.FriendRequests.Remove(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<String> DeclineFriendRequest(int requestId)
        {
            var request = await _context.FriendRequests.FindAsync(requestId);

            if (request == null || request.IsAccepted || request.IsDeclined)
            {
                return "Friend request not found or it has already been processed"; // Request not found or already processed
            }

            request.IsDeclined = true; // Mark as declined
            await _context.SaveChangesAsync();
            return "Friend request declined";
        }

        public async Task<List<FriendRequest>> GetPendingRequests(int userId)
        {
            return await _context.FriendRequests
                .Include(u=> u.Sender)
                .Include(u=> u.Receiver)
                .Where(fr => fr.ReceiverId == userId && !fr.IsAccepted && !fr.IsDeclined)
                .ToListAsync();
        }
    }
}
