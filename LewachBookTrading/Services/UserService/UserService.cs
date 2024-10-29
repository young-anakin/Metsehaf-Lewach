using DentalClinic.Services.Tools;
using LewachBookTrading.Context;
using LewachBookTrading.DTOs.UserDTO;
using LewachBookTrading.Model;
using Microsoft.EntityFrameworkCore;

namespace LewachBookTrading.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IToolsService _toolsService;

        public UserService(DataContext context, IToolsService toolsService)
        {
            _context = context;
            _toolsService = toolsService;

        }

        // Service for creating User
        public async Task<User> AddUser(AddUserDTO DTO)
        {
            var user = new User();
            //var address = new Address();

            user.StreetAddress = DTO.StreetAddress;
            user.City = DTO.City;
            user.Country = DTO.Country;
            user.Region = DTO.Region;
            user.PostalCode = DTO.PostalCode;
            user.StreetAddress = DTO.StreetAddress;
            user.SubCity = DTO.SubCity;

            user.PhoneNumber = DTO.PhoneNumber;
            user.Email = DTO.Email;
            user.FirstName = DTO.FirstName;
            user.LastName = DTO.LastName;
            user.UserName = DTO.UserName;
            user.CreatedAt = DateTime.Now;
            user.Photo = DTO.Photo;
            user.DateOfBirth = DTO.DateOfBirth;

            _toolsService.CreatePasswordHash(DTO.Password, out byte[] PH, out byte[] PS);
            user.PasswordHash = PH;
            user.PasswordSalt = PS;


            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;

        }
        public async Task<User> DeleteUser(int id)
        {
            var user = await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            return null;

        }
        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users
                .Include(u => u.JournalTags)
                //Include(u => u.Address) 
                .Where(u => u.Id == id).FirstOrDefaultAsync();
            if (user != null)
            {
                return user;

            }
            return null;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var user = await _context.Users
                .Include(u => u.JournalTags)

                .ToListAsync();
            if (user != null)
            {
                return user;

            }
            return null;
        }

        public async Task<string> ChangePassword(ChangePasswordDTO DTO)
        {
            var employee = await _context.Users
            .Where(e => e.Id == DTO.User_Id)
            .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Employee Not Found");
            var OldPassword = DTO.OldPassword;
            if (!_toolsService.VerifyPasswordHash(OldPassword, employee.PasswordHash, employee.PasswordSalt))
            {
                throw new UnauthorizedAccessException("Old Password Invalid!");
            }
            _toolsService.CreatePasswordHash(DTO.New_Password, out byte[] PH, out byte[] PS);
            employee.PasswordHash = PH;
            employee.PasswordSalt = PS;
            _context.Users.Update(employee);
            await _context.SaveChangesAsync();
            return $"Password Successfully changed to {DTO.New_Password}";
        }

        public async Task<LoginUserDisplayDTO> Login(LoginDTO login)
        {
            var user = await _context.Users
                .Where(u => u.UserName == login.UserName)
                .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("User Name Not found");


            if (!_toolsService.VerifyPasswordHash(login.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new UnauthorizedAccessException("Invalid password");
            }

            var loginEmployeeDisplayDTO = new LoginUserDisplayDTO
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Photo = user.Photo,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                Region = user.Region,
                PostalCode = user.PostalCode,
                StreetAddress = user.StreetAddress,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                City = user.City,
                Country = user.Country,
                SubCity = user.Country,


                Token = _toolsService.CreateToken(user)
            };

            return loginEmployeeDisplayDTO;


        }

        public async Task<User> UpdateUser(UpdateUserDTO DTO)
        {

            var user = await _context.Users
                //Include(u => u.Address)
                .Where(u => u.Id == DTO.id).FirstOrDefaultAsync();
            if (user != null)
            {
                user.DateOfBirth = DTO.DateOfBirth;
                user.Email = DTO.Email;
                user.FirstName = DTO.FirstName;
                user.LastName = DTO.LastName;
                user.PhoneNumber = DTO.PhoneNumber;
                user.UserName = DTO.UserName;
                user.Photo = DTO.Photo;
                user.UpdatedAt = DateTime.Now;
                user.Region = DTO.Region;
                user.City = DTO.City;
                user.PostalCode = DTO.PostalCode;
                user.Country = DTO.Country;
                user.SubCity = DTO.SubCity;
                user.StreetAddress = DTO.StreetAddress;
                


                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return user;

            }

            return null;

        }


    }
}
