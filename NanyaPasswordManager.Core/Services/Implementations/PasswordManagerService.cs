﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NanyaPasswordManager.Core.DTO;
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

        public async Task<PasswordResponseDto> AddPasswordAsync(PasswordRequestDto passwordRequestDto)
        {
             // TODO : get user by id 
            var passwordToAdd = new Password { 
              Username = passwordRequestDto.Username,
              Website = passwordRequestDto.Website,
              Email = passwordRequestDto.Email,
              ApplicationUserId = passwordRequestDto.UserId,
              WebsitePassword = passwordRequestDto.WebsitePassword,
              // TODO : assign it to passwordToAdd.User
              

            };
            // TODO : encrypt website password before saving
            try
            {
                var response = await _passwordManager.AddPassword(passwordToAdd);
                if(!response)
                    throw new Exception("An error occured while adding password");
                else                
                    return new PasswordResponseDto { Id = passwordToAdd.Id};               
            }
            catch (Exception ex)
            {
                throw new Exception ($"An error occurred while adding the password: {ex.Message}");
            }
        }

        public async Task<bool> UpdatePasswordAsync(string Id, UpdatePasswordDto password)
        {
            try
            {
                var existingPassword = await _passwordManager.GetPasswordById(Id);

                if (existingPassword.WebsitePassword != password.Password)
                {
                    throw new Exception("Your old password does not match the existing password");
                }

                if (existingPassword.WebsitePassword == password.NewPassword)
                {
                    throw new ArgumentException("Your new password is same as your old password");
                }

                if (existingPassword != null)
                {
                    existingPassword.WebsitePassword = password.NewPassword;
                    var response = await _passwordManager.UpdatePassword(existingPassword);
                    if (!response)
                    {
                        throw new Exception("Password update failed");
                    }
                return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"An error occurred while updating the password: {ex.Message}");

            }
        }

        //public async Task<IEnumerable<Password>> DeleteAllPasswordAsync()
        //{
        //    try
        //    {
        //        var allPasswords = await _passwordManager.DeleteAllPassword();

        //        if (allPasswords.Any())
        //        {
        //            await _passwordManager.DeleteAllPassword();
        //        }
        //        return allPasswords;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException($"An error occurred while deleting all passwords: {ex.Message}");
        //    }
        //}

        public async Task<bool> DeletePasswordAsync(string passwordId)
        {
            try
            {
                ValidateInput(passwordId);
                var existingPassword = await _passwordManager.GetPasswordById(passwordId);

                if (existingPassword == null)
                {
                    _passwordManager.DeletePassword(existingPassword);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"An error occurred while deleting the password: {ex.Message}");
            }
        }

        //public async Task<IEnumerable<Password>> GetAllPasswordAsync()
        //{
        //    try
        //    {
        //        var allPasswords = await _passwordManager.GetAllPassword();

        //        if (allPasswords != null)
        //        {
        //            await _passwordManager.GetAllPassword();
        //        }

        //        return  allPasswords.ToList();

        //    }
        //    catch (Exception ex)
        //    {
        //           throw new NotImplementedException($"An error occured while getting all passwords: {ex.Message}");
        //    }
        //}


        //public async Task<Password> GetPasswordByIdAsync(string id)
        //{
        //    try
        //    {
        //        var existingPassword = _passwordManager.GetPasswordById(id);
        //        if (existingPassword != null)
        //        {
        //            await _passwordManager.GetPasswordById(id);
        //        }
        //        return await existingPassword;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException($" An error occured while getting password{ex.Message}");

        //    }
        //}



    }


}
