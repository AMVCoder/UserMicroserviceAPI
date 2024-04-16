using Microsoft.AspNetCore.Mvc;
using UserMicroserviceAPI.API.DTOs;
using UserMicroserviceAPI.Core.Entities.User;
using UserMicroserviceAPI.Core.Interfaces.Aunthentication;
using UserMicroserviceAPI.Core.Services;

namespace UserMicroserviceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService; 
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = await _authService.Authenticate(userDto.Username, userDto.Password);
            if (user != null)
            {
                // Aquí deberías generar un token JWT o similar para el usuario
                var token = _authService.GenerateTokenAsync(user);
                return Ok(new { token });
            }

            return Unauthorized("Invalid username or password");
        }

    }
}
