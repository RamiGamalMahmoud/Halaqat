using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Halaqat.Data.Configurations
{
    internal class EducationalStageConfiguration : IEntityTypeConfiguration<EducationalStage>
    {
        public void Configure(EntityTypeBuilder<EducationalStage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasColumnType("NVARCHAR(20)");

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasData(new[]
            {
                new{ Id = 1, Name = "ما قبل الدراسة" },
                new{ Id = 2, Name = "إبتدائي" },
                new{ Id = 3, Name = "متوسطة" },
                new{ Id = 4, Name = "ثانوي" },
                new{ Id = 5, Name = "جامعي" },
            });
        }
    }
}
