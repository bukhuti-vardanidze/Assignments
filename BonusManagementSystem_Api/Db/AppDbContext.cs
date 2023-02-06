using Microsoft.EntityFrameworkCore;

namespace BonusManagementSystem_Api.Db
{
    public class AppDbContext : DbContext
    {
       



        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }

    }
}
