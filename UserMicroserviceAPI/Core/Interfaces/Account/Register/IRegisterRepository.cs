using UserMicroserviceAPI.Core.Entities.Users;

namespace UserMicroserviceAPI.Core.Interfaces.Account.Register
{
    public interface IRegisterRepository
    {
        Task AddUser(Users newUser);
        Task<bool>CheckUserExists(string email);
    }
}
