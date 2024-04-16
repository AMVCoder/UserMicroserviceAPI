using UserMicroserviceAPI.Core.Entities.User;

namespace UserMicroserviceAPI.Core.Interfaces.Aunthentication
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
