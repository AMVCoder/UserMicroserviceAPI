using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using UserMicroserviceAPI.API.DTOs;
using UserMicroserviceAPI.Core.Entities.Users;
using UserMicroserviceAPI.Core.Interfaces.Account;
using UserMicroserviceAPI.Core.Interfaces.Account.Login;
using UserMicroserviceAPI.Core.Interfaces.Account.Register;
using UserMicroserviceAPI.Core.Interfaces.Aunthentication;
using UserMicroserviceAPI.Core.Interfaces.Utility;
using UserMicroserviceAPI.Core.Services.Authentication;

namespace UserMicroserviceAPI.Core.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly IRegisterRepository _register;
        private readonly IAuthService _authService;
        private readonly IPasswordHasher _passHasher;

        public AccountService(IRegisterRepository register, IAuthService authService, IPasswordHasher passwordHasher)
        {
            _register = register;
            _authService = authService;
            _passHasher = passwordHasher;
        }

        public async Task<bool> LoginAsync(UserLoginDto loginInfo)
        {
            await _authService.Authenticate(loginInfo.Email, loginInfo.Password);
            return true;
        }

        public async Task<bool> RegisterUserAsync(UserRegistrationDto userInfo)
        {
            try {

                // Verificar si el usuario ya existe
                bool userExists = await _register.CheckUserExists(userInfo.Email);
                if (userExists)
                {
                    return false; // Usuario ya existe
                }

                Users userNew = new Users
                {
                    UserId = 2,
                    Username = userInfo.Name,
                    Email = userInfo.Email,

                };

                byte[] passwordHash, passwordSalt;
                _passHasher.CreatePasswordHash(userInfo.Password, out passwordHash, out passwordSalt);

                userNew.PasswordHash = passwordHash;
                userNew.PasswordSalt = passwordSalt;

                // Agregar el usuario al repositorio
                await _register.AddUser(userNew);
                return true; // Registro exitoso


            } catch 
            { 
                return false;
            }
        }

    }
}
