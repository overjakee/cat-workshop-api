using cat_workshop_api.DTOs.Auth;
using cat_workshop_api.Interfaces.Repositories;
using cat_workshop_api.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace cat_workshop_api.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public AuthService(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _jwtService = jwtService ?? throw new ArgumentNullException(nameof(jwtService));
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                throw new ArgumentException("Username and password must be provided.");

            var user = await _userRepository.GetUserByUserNameAndPasswordAsync(request.Username, request.Password);
            if (user == null)
                throw new UnauthorizedAccessException("Invalid username or password.");

            var token = await _jwtService.GenerateTokenAsync(user);
            if (string.IsNullOrEmpty(token))
                throw new InvalidOperationException("Failed to generate token.");

            return new LoginResponse()
            {
                Token = token,
                UserId = user.UserId,
                UserName = $"{user.FirstName} {user.LastName}"
            };
        }
    }
}
