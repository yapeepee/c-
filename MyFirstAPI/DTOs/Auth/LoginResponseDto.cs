

namespace MyFirstAPI.DTOs.Auth
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = "User"; // 預設角色為 User
        public DateTime ExpiresAt { get; set; }
    }
}