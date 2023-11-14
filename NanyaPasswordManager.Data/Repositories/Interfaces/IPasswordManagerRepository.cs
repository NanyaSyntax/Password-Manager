using NanyaPasswordManager.Model;

namespace NanyaPasswordManager.Data.Repositories.Interfaces
{
    public interface IPasswordManagerRepository
    {
        void AddPassword(PasswordManager password);
        Task<PasswordManager> GetPasswordById(string Id);
        Task<IEnumerable<PasswordManager>> GetAllPassword();
        Task<IEnumerable<PasswordManager>> DeleteAllPassword();
        void DeletePassword(PasswordManager password);
        Task<PasswordManager> UpdatePassword(string Id, PasswordManager password);

    }
}
