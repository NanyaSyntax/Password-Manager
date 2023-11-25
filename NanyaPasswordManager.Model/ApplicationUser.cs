using Microsoft.AspNetCore.Identity;

namespace NanyaPasswordManager.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Password> UserPasswords{ get; set; }

    }
}