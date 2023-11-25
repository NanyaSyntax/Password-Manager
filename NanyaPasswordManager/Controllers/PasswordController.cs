using Microsoft.AspNetCore.Mvc;
using NanyaPasswordManager.Core.DTO;
using NanyaPasswordManager.Core.Services.Interfaces;

namespace NanyaPasswordManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordManagerService _passwordManagerService;

        public PasswordController(IPasswordManagerService passwordManagerService)
        {
            _passwordManagerService = passwordManagerService;
        }

        [HttpPost("AddPassword")]
        public async Task<IActionResult> AddPassword ([FromBody] PasswordRequestDto passwordRequestDto) 
                                         => Ok(await _passwordManagerService.AddPasswordAsync(passwordRequestDto));

        //[HttpPut("UpdatePassword")]
        //public async Task<IActionResult> UpdatePassword(  string id, [FromBody] Password password) => Ok(await _passwordManagerService.UpdatePasswordAsync(id, password));

        //[HttpGet("GetPasswordById")]
        //public async Task<IActionResult> GetPasswordById(string id) => Ok(await _passwordManagerService.GetPasswordByIdAsync(id));

        //[HttpGet("GetAllPasswords")]
        //public async Task<IActionResult> GetAllPasswords() => Ok(await _passwordManagerService.GetAllPasswordAsync());

        //[HttpDelete("DeletePassword")]
        //public async Task<bool> DeletPassword(Password password) => (await _passwordManagerService.DeletePasswordAsync(password));

        //[HttpDelete("DeleteAllPasswords")]
        //public async Task<IActionResult> DeleteAllPasswords() => Ok(await _passwordManagerService.DeleteAllPasswordAsync());
    }
}
