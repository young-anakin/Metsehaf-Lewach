using DentalClinic.Services.Tools;
using LewachBookTrading.Context;
using LewachBookTrading.DTOs.FriendDTO;
using LewachBookTrading.Model;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> AddFriendship(AddFriendDTO DTO)
        {
            if (DTO.UserId == DTO.FriendId)
            {
                return false;
            }

            var existingFriendship = await _context.UserFriends
                                    .AnyAsync(uf =>
                                        (uf.UserId == DTO.UserId && uf.FriendId == DTO.FriendId) ||
                                        (uf.UserId == DTO.FriendId && uf.FriendId == DTO.UserId)
                                    );

            if (existingFriendship)
            {
                return false; // Friendship already exists
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

            _context.UserFriends.Add(userFriend);
            _context.UserFriends.Add(reciprocalFriendship);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
