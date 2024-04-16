using Microsoft.AspNetCore.Mvc;
using UserMicroserviceAPI.Core.Entities.User;
using UserMicroserviceAPI.Core.Interfaces;
using UserMicroserviceAPI.Core.Interfaces.Aunthentication;
using UserMicroserviceAPI.Infrastructure.Authentication.Authentication;

namespace UserMicroserviceAPI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ILoginRepository _loginRepository;
        private readonly ITokenService _tokenService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, ILoginRepository loginRepository, ITokenService tokenService)
        {
            _logger = logger;
            _loginRepository = loginRepository;
            _tokenService = tokenService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<User>> Get()
        {
            User user1 = new User() 
            { 
                UserId= 1,
                Username ="asff",
                Password = "asdfasd",
                Rol = ""
            };

            var token = _tokenService.GenerateToken(user1);

            var user = await _loginRepository.Login("JohnDoe", "password123");

            return (IEnumerable<User>)user;           
        }
    }
}