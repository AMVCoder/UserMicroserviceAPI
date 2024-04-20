using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using UserMicroserviceAPI.Core.Entities.Users;
using UserMicroserviceAPI.Core.Interfaces.Account.Login;
using UserMicroserviceAPI.Core.Interfaces.Aunthentication;
using UserMicroserviceAPI.Core.Interfaces.Utility;

namespace UserMicroserviceAPI.Core.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly ILoginRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHasher _passHasher;

        public AuthService(ILoginRepository userRepository, ITokenService tokenService, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _passHasher = passwordHasher;
        }

        public async Task<Users> Authenticate(string email,string password)
        {
            Users user = await _userRepository.Login(email);

            if (user != null && _passHasher.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return user;
            }

            return null;
        }

        public async Task<string> GenerateToken(Users user)
        {
            return _tokenService.GenerateToken(user);
        }

    }
}
