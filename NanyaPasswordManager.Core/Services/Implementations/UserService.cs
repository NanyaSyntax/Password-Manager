using Microsoft.AspNetCore.Identity;
using NanyaPasswordManager.Core.DTO;
using NanyaPasswordManager.Core.Services.Interfaces;
using NanyaPasswordManager.Data.Repositories.Interfaces;
using NanyaPasswordManager.Model;

namespace NanyaPasswordManager.Core.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService( UserManager<ApplicationUser> userManager) 
        {
            _userManager = userManager;
        }

        public async Task<string> CreateUserAsync(UserRequestDto userRequestDto)
        {
            var uniqueEmail = await _userManager.FindByEmailAsync(userRequestDto.Email);
            if (uniqueEmail != null)
            {
                return $" User with {uniqueEmail} already Exists:";
            }

            var newUser = new ApplicationUser
            {
                FirstName = userRequestDto.FirstName,
                LastName = userRequestDto.LastName,
                Email = userRequestDto.Email,
                UserName = userRequestDto.UserName,

            };        

            try
            {
                var response = await _userManager.CreateAsync(newUser, userRequestDto.Password);
                if (!response.Succeeded)
                {
                    return $"error occured while creating user";
                }
                return $"user created successfully";
            }
            catch (Exception ex)
            {
                throw new Exception ($"An error occurred while adding the user: {ex.Message}");
                
            }
        }
    }
}
