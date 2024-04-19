using Microsoft.AspNetCore.Mvc;
using UserMicroserviceAPI.API.DTOs;
using UserMicroserviceAPI.Core.Entities.Users;
using UserMicroserviceAPI.Core.Interfaces.Account;
using UserMicroserviceAPI.Core.Interfaces.Aunthentication;
using UserMicroserviceAPI.Core.Services;
using UserMicroserviceAPI.Core.Services.Account;

namespace UserMicroserviceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
     
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _accountService.LoginAsync(userDto);
            //if (user != null)
            //{
            //    // Aquí deberías generar un token JWT o similar para el usuario
            //    string token = await _authService.GenerateToken(user);
            //    return Ok(new { token });
            //} 

            return Unauthorized("Invalid username or password");
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] UserRegistrationDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _accountService.RegisterUserAsync(registerDto);
                if (result)
                {
                    return Ok("Registro exitoso.");
                }
                else
                {
                    return BadRequest("No se pudo registrar el usuario. Es posible que el email ya esté en uso.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

    }
}
