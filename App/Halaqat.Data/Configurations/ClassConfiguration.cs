using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Halaqat.Data.Configurations
{
    internal class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("NVARCHAR(20)");

            builder.HasOne(x => x.EducationalStage)
                .WithMany(x => x.Classes)
                .HasForeignKey("EducationalStageId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new[]
            {
                new{ Id = 1, Name = "أول", EducationalStageId = 2 },
                new{ Id = 2, Name = "ثاني", EducationalStageId = 2 },
                new{ Id = 3, Name = "ثالث", EducationalStageId = 2 },
                new{ Id = 4, Name = "رابع", EducationalStageId = 2 },
                new{ Id = 5, Name = "خامس", EducationalStageId = 2 },
                new{ Id = 6, Name = "سادس", EducationalStageId = 2 },

                new{ Id = 7, Name = "أول", EducationalStageId = 3 },
                new{ Id = 8, Name = "ثاني", EducationalStageId = 3 },
                new{ Id = 9, Name = "ثالث", EducationalStageId = 3 },

                new{ Id = 10, Name = "أول", EducationalStageId = 4 },
                new{ Id = 11, Name = "ثاني", EducationalStageId = 4 },
                new{ Id = 12, Name = "ثالث", EducationalStageId = 4 },


                new{ Id = 13, Name = "أول", EducationalStageId = 5 },
                new{ Id = 14, Name = "ثاني", EducationalStageId = 5 },
                new{ Id = 15, Name = "ثالث", EducationalStageId = 5 },
                new{ Id = 16, Name = "رابع", EducationalStageId = 5 },
            });
        }
    }
}
