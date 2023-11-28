using Microsoft.AspNetCore.Mvc;
using NanyaPasswordManager.Core.DTO;
using NanyaPasswordManager.Model;

namespace NanyaPasswordManager.Core.Services.Interfaces
{
    public interface IPasswordManagerService
    {
        Task<PasswordResponseDto> AddPasswordAsync(PasswordRequestDto passwordRequestDto);
        //Task<bool> DeletePasswordAsync(Password password);
        Task<bool> UpdatePasswordAsync(string Id, UpdatePasswordDto password);
        //Task<Password> GetPasswordByIdAsync(string id);
        //Task<IEnumerable<Password>> GetAllPasswordAsync();
        //Task<bool> DeleteAllPasswordAsync();
    }
}
