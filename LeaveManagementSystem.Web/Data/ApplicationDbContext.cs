using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole { 
                Id = "eec79d06-e0fc-4f1f-9048-f818c845d656",
                Name = "Employee",
                NormalizedName = "EMPLOYEE"
            }, 
            new IdentityRole {
                Id = "39f80ae4-8c55-412b-9b8a-d35f459f9692",
                Name = "Supervisor",
                NormalizedName = "SUPERVISOR"
            }, 
            new IdentityRole {
                Id = "934cd103-601a-462c-afbc-9b34255b2554",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            }
         );

       // var hasher = new PasswordHasher<ApplicationUser>();

        builder.Entity<ApplicationUser>().HasData(
            new ApplicationUser
        {
                Id = "9d59b512-349d-4f8d-bccc-27c415d74a18",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                // PasswordHash = hasher.HashPassword(null, "Password#1"),
                PasswordHash = "AQAAAAIAAYagAAAAEHd2wJjOkSsgCbvCZEi8HtDfrDiP3Cw1traXysvxU4KvG4b1hkVZczvP0lkxYfnkMQ==", // Pre-computed hash for "Password#1"
                EmailConfirmed = true,
                ConcurrencyStamp = "stamp-admin-user", // Adding a static value
                SecurityStamp = "SECURITYSTAMP", // Adding a static value
                FirstName = "Admin",
                LastName = "Admin",
                DateOfBirth = new DateOnly(1979, 08, 31)
            });

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "934cd103-601a-462c-afbc-9b34255b2554",
                UserId = "9d59b512-349d-4f8d-bccc-27c415d74a18"
            });
    }

    public DbSet<LeaveType> LeaveTypes { get; set; }
}
