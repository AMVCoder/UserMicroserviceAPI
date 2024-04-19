using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using UserMicroserviceAPI.Core.Entities.Users;
using UserMicroserviceAPI.Core.Interfaces.Account.Login;
using UserMicroserviceAPI.Core.Interfaces.Aunthentication;

namespace UserMicroserviceAPI.Core.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly ILoginRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthService(ILoginRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<Users> Authenticate(string email,string password)
        {
            Users user = await _userRepository.Login(email);

            if (user != null && VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return user;
            }

            return null;
        }

        public async Task<string> GenerateToken(Users user)
        {
            return _tokenService.GenerateToken(user);
        }

        // Método para verificar el hash de la contraseña
        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", nameof(password));

            using (var hmac = new HMACSHA256(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
