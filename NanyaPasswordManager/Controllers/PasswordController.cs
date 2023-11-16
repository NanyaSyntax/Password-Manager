using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NanyaPasswordManager.Core.Services.Interfaces;
using NanyaPasswordManager.Model;

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
        public async Task<IActionResult> AddPassword ([FromBody] PasswordManager password)
        {
            return Ok(_passwordManagerService.AddPasswordAsync(password));
        }

        [HttpPut("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword(  string id, [FromBody] PasswordManager password)
        {
            return Ok(await _passwordManagerService.UpdatePasswordAsync(id, password));
        }


        [HttpGet("GetPasswordById")]
        public async Task<IActionResult> GetPasswordById(string id) => Ok(await _passwordManagerService.GetPasswordByIdAsync(id));

        [HttpGet("GetAllPasswords")]
        public async Task<IActionResult> GetAllPasswords() => Ok(await _passwordManagerService.GetAllPasswordAsync());


    }

    
}
