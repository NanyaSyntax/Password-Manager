using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanyaPasswordManager.Core.DTO
{
    public class PasswordRequestDto
    {
        [Required]
        public string Website { get; set; }
        public string Username { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }    

    }
}
