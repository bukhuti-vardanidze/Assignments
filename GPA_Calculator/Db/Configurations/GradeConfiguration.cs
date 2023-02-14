using GPA_Calculator.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GPA_Calculator.Db.Configurations
{
    public class GradeConfiguration :IEntityTypeConfiguration<GradeEntity>
    {
        public void Configure(EntityTypeBuilder<GradeEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.StudentEntity).WithMany().HasForeignKey(x => x.StudentId);
            builder.HasOne(x => x.SubjectEntity).WithMany().HasForeignKey(x => x.SubjectId);

        }
        
    }
}
