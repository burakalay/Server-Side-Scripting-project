using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecurePasswordApp.Models;

namespace SecurePasswordApp.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }



    // PasswordCredentials table in the database
    public DbSet<PasswordCredential> PasswordCredentials { get; set; }

    // UserProfiles table in the database
    public DbSet<UserProfile> UserProfiles { get; set; }
}
