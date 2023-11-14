using NanyaPasswordManager.Model;

namespace NanyaPasswordManager.Core.Services.Interfaces
{
    public interface IPasswordManagerService
    {
        Task<PasswordManager> AddPassword(PasswordManager password);
        Task<PasswordManager> DeletePassword(PasswordManager password);
        Task<PasswordManager> UpdatePassword(string id, PasswordManager password);
        Task<PasswordManager> GetPasswordById(string id);
        Task<IEnumerable<PasswordManager>> GetAllPassword();

    }
}
