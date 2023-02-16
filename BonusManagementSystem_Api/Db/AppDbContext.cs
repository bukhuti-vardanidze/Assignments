using BonusManagementSystem_Api.Db.Configuration;
using BonusManagementSystem_Api.Db.Entity;
using Microsoft.EntityFrameworkCore;

namespace BonusManagementSystem_Api.Db
{
    public class AppDbContext : DbContext
    {
       
        public DbSet<EmployeeEntity> employees { get; set; }
        public DbSet<BonusEntity> bonuses { get; set; }



        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BonusConfiguration());
            base.OnModelCreating(builder);
            
        }

    }
}
