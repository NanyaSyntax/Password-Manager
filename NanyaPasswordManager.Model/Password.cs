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
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
