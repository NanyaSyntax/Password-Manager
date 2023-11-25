using Microsoft.AspNetCore.Mvc;
using NanyaPasswordManager.Core.DTO;
using NanyaPasswordManager.Core.Services.Interfaces;

namespace NanyaPasswordManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserRequestDto userRequestDto)
                                        => Ok(await _userService.CreateUserAsync(userRequestDto));
    }
}
