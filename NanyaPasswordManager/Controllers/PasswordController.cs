using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> AddPassword([FromBody] PasswordManager password)
        {
            return Ok(_passwordManagerService.AddPasswordAsync(password));
            
        }




    }
}
