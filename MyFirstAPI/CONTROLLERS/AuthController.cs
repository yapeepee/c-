using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.DTOs.Auth;
using MyFirstAPI.Models;
using MyFirstAPI.Services;

namespace MyFirstAPI.CONTROLLERS
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        
        public AuthController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }
        
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            if (loginDto.Username == "admin" && loginDto.Password == "password123")
            {
                var user = new User
                {
                    Id = 1,
                    Username = "admin",
                    Email = "admin@example.com",
                    Role = "Admin"
                };
                
                var token = _jwtService.GenerateToken(user);
                
                return Ok(new LoginResponseDto
                {
                    Token = token,
                    ExpiresAt = DateTime.UtcNow.AddHours(24),
                    Username = user.Username,
                    Role = user.Role
                });
            }
            
            return Unauthorized(new { message = "帳號或密碼錯誤" });
        }
    }
}