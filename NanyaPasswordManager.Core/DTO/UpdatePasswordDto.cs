using System.ComponentModel.DataAnnotations;

namespace NanyaPasswordManager.Core.DTO
{
    public class UpdatePasswordDto
    {

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Compare("NewPassword")]
        public string  ConfirmPassword { get; set; }
    }
}
