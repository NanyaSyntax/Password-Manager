using Microsoft.EntityFrameworkCore;
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

        public async Task<PasswordManager> AddPasswordAsync(PasswordManager password)
        {
            try
            {
                var addedPassword = await _passwordManager.AddPassword(password);

                if (addedPassword == null)
                {
                    throw new ArgumentException("An input must be made");
                }
                return addedPassword;
            }
            catch (Exception ex)
            {
                throw new Exception ($"An error occurred while adding the password: {ex.Message}");
            }
        }

        public async Task<IEnumerable<PasswordManager>> DeleteAllPasswordAsync()
        {
            try
            {
                var allPasswords = await _passwordManager.DeleteAllPassword();

                if (allPasswords.Any())
                {
                    await _passwordManager.DeleteAllPassword();
                }
                return allPasswords;
            }
            catch (Exception ex)
            {
                throw new ArgumentException ($"An error occurred while deleting all passwords: {ex.Message}");
            }
        }

        public async Task<PasswordManager> DeletePasswordAsync(PasswordManager password)
        {
            try
            {
                var existingPassword = await _passwordManager.GetPasswordById(password.Id);

                if (existingPassword != null)
                {
                   _passwordManager.DeletePassword(existingPassword);
                }

                return existingPassword;
            }
            catch (Exception ex)
            {
                throw new ArgumentException ($"An error occurred while deleting the password: {ex.Message}");
            }
        }

        public async Task<IEnumerable<PasswordManager>> GetAllPasswordAsync()
        {
            try
            {
                var allPasswords = await _passwordManager.GetAllPassword();

                if (allPasswords != null)
                {
                    await _passwordManager.GetAllPassword();
                }

                return  allPasswords.ToList();

            }
            catch (Exception ex)
            {
                   throw new NotImplementedException($"An error occured while getting all passwords: {ex.Message}");
            }
        }


        public async Task<PasswordManager> GetPasswordByIdAsync(string id)
        {
            try
            {
                var existingPassword = _passwordManager.GetPasswordById(id);
                if (existingPassword != null)
                {
                    await _passwordManager.GetPasswordById(id);
                }
                return await existingPassword;

            }
            catch (Exception ex)
            {
                throw new ArgumentException($" An error occured while getting password{ex.Message}");

            }
        }

        public async Task<PasswordManager> UpdatePasswordAsync(string id, PasswordManager password)
        {
            try
            {
                // Find the existing password by its ID
                var existingPassword = await _passwordManager.GetPasswordById(id);

                if (existingPassword != null)
                {
                    await _passwordManager.UpdatePassword(id, existingPassword);                }

                return existingPassword;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"An error occurred while updating the password: {ex.Message}");
                
            }
        }

    }
        
    
}
