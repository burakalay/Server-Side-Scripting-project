using EncriptifyApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EncriptifyApp.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    // PasswordCredentials table in the database
    public DbSet<PasswordCredential> PasswordCredentials { get; set; }

    //UserDetails table in database
    public DbSet<UserDetail> UserDetails { get; set; }
}
