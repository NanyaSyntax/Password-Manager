using NanyaPasswordManager.Model;

namespace NanyaPasswordManager.Data.Repositories.Interfaces
{
    public interface IPasswordManagerRepository
    {
        Task<bool> AddPassword(Password password);
        Task<Password> GetPasswordById(string Id);
        Task<IEnumerable<Password>> GetAllPassword();
        Task<bool> DeleteAllPassword();
        Task<bool> DeletePassword(Password password);
        Task<bool> UpdatePassword(Password password);

    }
}
