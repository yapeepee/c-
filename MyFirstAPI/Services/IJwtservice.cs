using MyFirstAPI.Models;

namespace MyFirstAPI.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}