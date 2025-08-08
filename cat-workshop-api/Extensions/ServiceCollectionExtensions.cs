using cat_workshop_api.Interfaces.Repositories;
using cat_workshop_api.Interfaces.Services;
using cat_workshop_api.Repositories;
using cat_workshop_api.Services;

namespace cat_workshop_api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtService, JwtService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            return services;
        }
    }
}
