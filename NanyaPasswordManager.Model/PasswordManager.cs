using System.ComponentModel.DataAnnotations.Schema;

namespace NanyaPasswordManager.Model
{
    public class PasswordManager : BaseEntity
    {
        public string Website { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
