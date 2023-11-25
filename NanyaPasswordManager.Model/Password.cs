using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NanyaPasswordManager.Model
{
    public class Password : BaseEntity
    {
        public string Website { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string WebsitePassword { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
