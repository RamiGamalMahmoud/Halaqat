using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Halaqat.Data.Configurations
{
    internal class AcademicQualificationConfiguration : IEntityTypeConfiguration<AcademicQualification>
    {
        public void Configure(EntityTypeBuilder<AcademicQualification> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("NVARCHAR(20)");
            builder.HasIndex(x => x.Name).IsUnique();

#if DEBUG
            builder.HasData(
                [
                    new AcademicQualification() { Id = 1, Name = "جامعي" },
                    new AcademicQualification() { Id = 2, Name = "متوسط" },
                    new AcademicQualification() { Id = 3, Name = "دكتوراه" },
                    new AcademicQualification() { Id = 4, Name = "بدون" },
                ]);
#endif
        }
    }
}
