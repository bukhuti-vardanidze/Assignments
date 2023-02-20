using BonusManagementSystem_Api.Db.Configuration;
using BonusManagementSystem_Api.Db.Entity;
using Microsoft.EntityFrameworkCore;

namespace BonusManagementSystem_Api.Db
{
    public class AppDbContext : DbContext
    {
      
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<BonusEntity> Bonuses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BonusConfiguration());
            base.OnModelCreating(builder);
            
        }

    }
}
