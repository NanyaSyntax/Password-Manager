using Microsoft.AspNetCore.Identity;
using System.Security.Principal;

namespace NanyaPasswordManager.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<PasswordManager> PasswordManagers{ get; set; }

    }
}