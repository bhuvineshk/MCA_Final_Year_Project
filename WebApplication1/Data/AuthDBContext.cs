using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InsuraNex.Data
{
    public class AuthDBContext : IdentityDbContext
    {
        public AuthDBContext(DbContextOptions<AuthDBContext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var superAdminRoleId = "50269be2-66d0-4217-a8b3-64df1f4acd27";

            var adminRoleId = "aaf77c03 -ccc9-47cc-8e37-c0f0078fa961";
            var userRoleId = "b78e7b1c -5fc8-4f68-a5aa-b40ad81d815a";


            var roles = new List<IdentityRole>
        {
            new IdentityRole()
            {
                Name = "SuperAdmin",
                NormalizedName = "SuperAdmin",
                Id =superAdminRoleId,
                ConcurrencyStamp = superAdminRoleId
            },
            new IdentityRole()
            {
                Name = "Admin",
                NormalizedName = "Admin",
                Id =adminRoleId,
                ConcurrencyStamp = adminRoleId
            },
            new IdentityRole()
            {
                Name = "User",
                NormalizedName = "User",
                Id =userRoleId,
                ConcurrencyStamp = userRoleId
            }

        };

            builder.Entity<IdentityRole>().HasData(roles);
            var superAdminId = "9bd868d0-5833-4cf3-838e-af2edede220d";
            var superAdminUser = new IdentityUser()
            {
                Id = superAdminId,
                UserName = "AgentSupportAdmin@taken.com",
                Email = "AgentSupportAdmin@taken.com",
                NormalizedEmail = "AgentSupportAdmin@taken.com".ToUpper(),
                NormalizedUserName = "AgentSupportAdmin@taken.com".ToUpper()

            };

            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(superAdminUser, "Superadmin@123");


            builder.Entity<IdentityUser>().HasData(superAdminUser);

            var superAdminRoles = new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>()
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>()
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>()
                {
                    RoleId = userRoleId,
                    UserId = superAdminId
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
        }
    }
}

