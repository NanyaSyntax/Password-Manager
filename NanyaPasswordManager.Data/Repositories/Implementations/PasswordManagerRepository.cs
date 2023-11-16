using Microsoft.EntityFrameworkCore;
using NanyaPasswordManager.Data.Repositories.Interfaces;
using NanyaPasswordManager.Model;

namespace NanyaPasswordManager.Data.Repositories.Implementations
{
    public class PasswordManagerRepository : IPasswordManagerRepository
    {
        private readonly NanyaPwdMngrDbContext _context;

        public PasswordManagerRepository(NanyaPwdMngrDbContext context)
        {
            _context = context;
        }
        public async Task<PasswordManager> AddPassword(PasswordManager password)
        {
            _context.passwordManagers.Add(password);
            await _context.SaveChangesAsync();
            return password;
        }

        public async void DeletePassword(PasswordManager password)
        {
            _context.passwordManagers.Remove(password);
            await _context.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<PasswordManager>> DeleteAllPassword()
        {
            _context.passwordManagers.RemoveRange();
            await _context.SaveChangesAsync();
            return await _context.passwordManagers.ToListAsync();
        }

        public async Task<IEnumerable<PasswordManager>> GetAllPassword()
        {
            return await _context.passwordManagers.ToListAsync();
        }

        public async Task<PasswordManager> GetPasswordById(string Id)
        {
            return await _context.passwordManagers.FindAsync(Id);
            
        }

        public async Task<PasswordManager> UpdatePassword(string Id,PasswordManager password)
        {
            var passwordUpdate = await _context.passwordManagers.FindAsync(Id);
            await _context.SaveChangesAsync();
            return passwordUpdate;
        }

       

      
    }
}
