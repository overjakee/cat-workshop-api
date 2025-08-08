using cat_workshop_api.Data;
using cat_workshop_api.Interfaces.Repositories;
using cat_workshop_api.Models;
using Microsoft.EntityFrameworkCore;

namespace cat_workshop_api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CatDbContext _context;
        public UserRepository(CatDbContext context)
        {
            _context = context;
        }   
        public async Task<User?> GetUserByUserNameAndPasswordAsync(string username, string password)
        {
            return await _context.Users
                .Where(u => u.Username == username && u.Password == password)
                .FirstOrDefaultAsync();
        }
    }
}
