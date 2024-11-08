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
                .HasForeignKey(x => x.ProgramDayId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Notes)
                .HasColumnType("VARCHAR(20)")
                .IsRequired(false);

            builder.HasOne(x => x.Sorah)
                .WithMany()
                .IsRequired(false)
                .HasForeignKey(x => x.SorahId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ProgramDayItemType)
                .WithMany()
                .IsRequired()
                .HasForeignKey(x => x.ProgramDayItemTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VerseFrom)
                .WithMany()
                .HasForeignKey(x => x.VerseFromId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasOne(x => x.VerseTo)
                .WithMany()
                .HasForeignKey(x => x.VerseToId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.Ignore(x => x.HasNotes).Ignore(x => x.HasSorah).Ignore(x => x.HasVerseFrom).Ignore(x => x.HasVerseTo);
        }
    }
}
