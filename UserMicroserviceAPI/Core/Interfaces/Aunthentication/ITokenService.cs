using UserMicroserviceAPI.Core.Entities.Users;

namespace UserMicroserviceAPI.Core.Interfaces.Aunthentication
{
    public interface ITokenService
    {
        string GenerateToken(Users user);
        bool ValidateToken(string token);
    }
}
