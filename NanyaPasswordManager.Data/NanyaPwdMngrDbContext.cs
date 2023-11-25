using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NanyaPasswordManager.Model;

namespace NanyaPasswordManager.Data
{
    public class NanyaPwdMngrDbContext : IdentityDbContext<ApplicationUser>
    {
        public NanyaPwdMngrDbContext(DbContextOptions<NanyaPwdMngrDbContext> options) : base(options)
        {
        }

        public DbSet<Password> UserPasswords { get; set; }

    }
}