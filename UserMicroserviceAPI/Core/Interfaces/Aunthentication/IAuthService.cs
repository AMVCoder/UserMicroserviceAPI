using UserMicroserviceAPI.Core.Entities.Users;

namespace UserMicroserviceAPI.Core.Interfaces.Aunthentication
{
    public interface IAuthService
    {
        Task<Users> Authenticate(string email, string password);
        Task<string> GenerateToken(Users user);
    }
}
