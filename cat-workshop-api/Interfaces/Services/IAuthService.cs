using cat_workshop_api.DTOs.Auth;

namespace cat_workshop_api.Interfaces.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);
    }
}
