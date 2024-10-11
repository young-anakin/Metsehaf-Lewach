//using DentalClinic.Models;

using LewachBookTrading.Model;

namespace DentalClinic.Services.Tools
{
    public interface IToolsService
    {
        int CalculateAge(DateTime birthDate);
        DateTime CalculateDOB(int age);
        void CreatePasswordHash(string Password, out byte[] PasswordHash, out byte[] PasswordSalt);
        string CreateToken(User UA);
        string[] ReturnArrayofCommaSeparatedStrings(string inputString);
        bool VerifyPasswordHash(string Password, byte[] PasswordHash, byte[] PasswordSalt);
    }
}