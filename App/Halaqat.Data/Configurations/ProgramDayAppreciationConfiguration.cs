using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Halaqat.Data.Configurations
{
    internal class ProgramDayAppreciationConfiguration : IEntityTypeConfiguration<ProgramDayAppreciation>
    {
        public void Configure(EntityTypeBuilder<ProgramDayAppreciation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Teacher)
                .WithMany()
                .HasForeignKey(x => x.TeacherId);

            builder.HasOne(x => x.Student)
                .WithMany()
                .HasForeignKey(x => x.StudentId);

            builder.HasOne(x => x.ProgramDayItemType)
                .WithMany()
                .HasForeignKey(x => x.ProgramDayItemTypeId);

            builder.HasOne(x => x.ProgramDay)
                .WithMany(x => x.ProgramDayAppreciations)
                .HasForeignKey(x => x.ProgramDayId);

            builder.HasOne(x => x.Appreciation)
                .WithMany()
                .HasForeignKey(x => x.AppreciationId);
        }
    }
}
