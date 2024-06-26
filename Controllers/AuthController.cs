using Microsoft.AspNetCore.Mvc;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services;
using Microsoft.Extensions.Logging;

namespace AuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            // to log the login attempt
            _logger.LogInformation($"Login attempt for user: {userLogin.Username}");

            var token = _authService.Authenticate(userLogin.Username, userLogin.Password);

            if (token == null)
            {
                // to log the unsuccessful login
                _logger.LogWarning($"Failed login attempt for user: {userLogin.Username}");
                return Unauthorized(new { message = "Invalid credentials" });
            }

            // to log the successful login of user
            _logger.LogInformation($"User logged in successfully: {userLogin.Username}");

            return Ok(new { Token = token });
        }
        
    }
}
