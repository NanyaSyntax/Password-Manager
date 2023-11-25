using NanyaPasswordManager.Data.Repositories.Interfaces;
using NanyaPasswordManager.Model;

namespace NanyaPasswordManager.Data.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly NanyaPwdMngrDbContext _context;

        public UserRepository(NanyaPwdMngrDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateUser(ApplicationUser user)
        {
            _context.Users.Add(user);
            return await _context.SaveChangesAsync()> 0;
        }
    }
}
