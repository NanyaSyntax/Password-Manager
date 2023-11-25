using NanyaPasswordManager.Core.DTO;
using NanyaPasswordManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanyaPasswordManager.Core.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> CreateUserAsync(UserRequestDto userRequestDto);
    }
}
