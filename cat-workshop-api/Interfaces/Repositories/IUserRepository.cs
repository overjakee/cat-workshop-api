using cat_workshop_api.Models;

namespace cat_workshop_api.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUserNameAndPasswordAsync(string username ,string password);
    }
}
