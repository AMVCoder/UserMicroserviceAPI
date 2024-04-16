using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using UserMicroserviceAPI.Core.Entities.User;
using UserMicroserviceAPI.Core.Interfaces;
using UserMicroserviceAPI.Core.Interfaces.Aunthentication;

namespace UserMicroserviceAPI.Core.Services
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

        public string GenerateTokenAsync(User user)
        {
            return _tokenService.GenerateToken(user);
        }

        public async Task<User> Authenticate(string username, string password)
        {
            User user = await _userRepository.Login(username, password);

            if (user != null && VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return user;
            }

            return null;
        }


        // Método para verificar el hash de la contraseña
        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", nameof(password));

            using (var hmac = new HMACSHA256(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
