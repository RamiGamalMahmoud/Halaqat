using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Halaqat.Data.Configurations
{
    internal class ProgramDayItemConfiguration : IEntityTypeConfiguration<ProgramDayItem>
    {
        public void Configure(EntityTypeBuilder<ProgramDayItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.ProgramDay)
                .WithMany(x => x.ProgramDayItems)
                .HasForeignKey("ProgramDayId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Sorah)
                .WithMany()
                .IsRequired()
                .HasForeignKey("SorahId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ProgramDayItemType)
                .WithMany()
                .IsRequired()
                .HasForeignKey("ProgramDayItemTypeId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VerseFrom)
                .WithMany()
                .HasForeignKey("VerseFromId")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasOne(x => x.VerseTo)
                .WithMany()
                .HasForeignKey("VerseToId")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
        }
    }
}
