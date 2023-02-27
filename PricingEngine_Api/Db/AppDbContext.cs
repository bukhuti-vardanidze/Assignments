using Microsoft.EntityFrameworkCore;
using PricingEngine_Api.Db.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PricingEngine_Api.Db
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<DataBaseInput> DataBaseInputs { get; set; }
        public DbSet<UserInput> UserInputs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }

    }
}