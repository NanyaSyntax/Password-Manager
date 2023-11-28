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
        public async Task<bool> AddPassword(Password password)
        {
            _context.UserPasswords.Add(password);
            return await SaveChanges();
        }
        public async Task<bool> DeletePassword(Password password)
        {
            _context.UserPasswords.Remove(password);
            return await SaveChanges();
        }
        public async Task<bool> DeleteAllPassword()
        {
            _context.UserPasswords.RemoveRange();
            return await SaveChanges();
        }
        public async Task<IEnumerable<Password>> GetAllPassword() =>  await _context.UserPasswords.ToListAsync();

        public async Task<Password> GetPasswordById(string Id) => await _context.UserPasswords.FirstOrDefaultAsync(x=>x.Id == Id);

        public async Task<bool> UpdatePassword(Password password)
        {
            _context.Update(password);
            return await SaveChanges();
        }

        private async Task<bool> SaveChanges() => await _context.SaveChangesAsync()>0;
        

        
    }
}
