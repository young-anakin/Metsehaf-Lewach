using LewachBookTrading.DTOs.UserDTO;
using LewachBookTrading.Model;

namespace LewachBookTrading.Services.UserService
{
    public interface IUserService
    {
        Task<User> AddUser(AddUserDTO DTO);
        Task<string> ChangePassword(ChangePasswordDTO DTO);
        Task<User> DeleteUser(int id);
        Task<List<User>> GetAllUsers();
        Task<User> GetUser(int id);
        Task<User> UpdateUser(UpdateUserDTO DTO);
    }
}