using cat_workshop_api.Models;

namespace cat_workshop_api.Interfaces.Services
{
    public interface IJwtService
    {
        Task<string> GenerateTokenAsync(User user);
    }
}
