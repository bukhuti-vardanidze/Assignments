using GPA_Calculator.Db.Configurations;
using GPA_Calculator.Db.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace GPA_Calculator.Db
{
    public class AppDbContext : DbContext
    {
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<SubjectEntity> Subjects { get; set; }
        public DbSet<GradeEntity> Grades { get; set; }
        


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GradeConfiguration());
            base.OnModelCreating(builder);
        }

    }
}
