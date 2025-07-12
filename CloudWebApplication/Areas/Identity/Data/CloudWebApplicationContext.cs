using CloudWebApplication.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CloudWebApplication.Models;

namespace CloudWebApplication.Data;

public class CloudWebApplicationContext : IdentityDbContext<CloudWebApplicationUser>
{
    public CloudWebApplicationContext(DbContextOptions<CloudWebApplicationContext> options)
        : base(options)
    {
    }
    public DbSet<Flower> Flower { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
