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

    // Users table in the database
    public DbSet<User> Users { get; set; }

    // PasswordCredentials table in the database
    public DbSet<PasswordCredential> PasswordCredentials { get; set; }

    // UserProfiles table in the database
    public DbSet<UserProfile> UserProfiles { get; set; }
}
