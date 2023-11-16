using NanyaPasswordManager.Core.DTO;
using NanyaPasswordManager.Model;

namespace NanyaPasswordManager.Core.Services.Interfaces
{
    public interface IPasswordManagerService
    {
        Task<PasswordManager> AddPasswordAsync(PasswordManager password);
        Task<PasswordManager> DeletePasswordAsync(PasswordManager password);
        Task<PasswordManager> UpdatePasswordAsync(string id, PasswordManager password);
        Task<PasswordManager> GetPasswordByIdAsync(string id);
        Task<IEnumerable<PasswordManager>> GetAllPasswordAsync();
        Task<IEnumerable<PasswordManager>> DeleteAllPasswordAsync();

    }
}
