using UserMicroserviceAPI.API.DTOs;
using UserMicroserviceAPI.Core.Entities.Users;

namespace UserMicroserviceAPI.Core.Interfaces.Account
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(UserLoginDto loginInfo);
        Task<bool> RegisterUserAsync(UserRegistrationDto userInfo);
    }
}
