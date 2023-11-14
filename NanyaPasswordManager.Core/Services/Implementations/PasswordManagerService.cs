using NanyaPasswordManager.Core.Services.Interfaces;
using NanyaPasswordManager.Data.Repositories.Interfaces;
using NanyaPasswordManager.Model;

namespace NanyaPasswordManager.Core.Services.Implementations
{
    public class PasswordManagerService : IPasswordManagerService
    {
        private readonly IPasswordManagerRepository _passwordManager;

        public PasswordManagerService(IPasswordManagerRepository passwordManager)
        {
            _passwordManager = passwordManager;
        }
        public async Task<PasswordManager> AddPassword(PasswordManager password)
        {
            var addPassword = await _passwordManager.AddPasswordAsync(password);
            if(addPassword == null)
            {
                throw new ArgumentException("An input must be made");
            }
            return addPassword;
        }

        public Task<PasswordManager> DeletePassword(PasswordManager password)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PasswordManager>> GetAllPassword()
        {
            throw new NotImplementedException();
        }

        public Task<PasswordManager> GetPasswordById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<PasswordManager> UpdatePassword(string id, PasswordManager password)
        {
            throw new NotImplementedException();
        }
    }
}
