using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BonusManagementSystem_Api.Db.Entity;

namespace BonusManagementSystem_Api.Db.Configuration
{
    public class BonusConfiguration : IEntityTypeConfiguration<BonusEntity>
    {
        public void Configure(EntityTypeBuilder<BonusEntity> builder)
        {
            
           builder.HasOne(x => x.EmployeeEntity).WithMany(x=>x.BonusEntity).HasForeignKey(x=>x.EmployeeId);
            
        }

    }
}
