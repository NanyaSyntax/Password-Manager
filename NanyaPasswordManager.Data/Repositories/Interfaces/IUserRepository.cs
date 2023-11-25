using NanyaPasswordManager.Model;

namespace NanyaPasswordManager.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> CreateUser(ApplicationUser user);
    }
}
