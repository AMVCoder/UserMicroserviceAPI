using UserMicroserviceAPI.Core.Entities.User;

namespace UserMicroserviceAPI.Core.Interfaces.Aunthentication
{
    public interface IAuthService
    {
        Task<User> Authenticate(string username, string password);
        string GenerateTokenAsync(User user);
    }
}
