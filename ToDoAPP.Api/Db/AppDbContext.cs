using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Api.Db.Entities;

namespace ToDoApp.Api.Db
{
    public class AppDbContext : IdentityDbContext<UserEntity, RoleEntity, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



            //builder.Entity<UserEntity>().ToTable("Users");
            //builder.Entity<RoleEntity>().ToTable("Roles");
            //builder.Entity<IdentityUserRole<int>>().ToTable("UserRoles");
            //builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
            //builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            //builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
            //builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");

            // builder.Ignore<IdentityUserToken<int>>();

            // builder.Entity<IdentityUserRole<int>>().HasKey(p => new { p.UserId, p.RoleId });
        }

    }
}