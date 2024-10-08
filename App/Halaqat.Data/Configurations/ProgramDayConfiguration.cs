using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Halaqat.Data.Configurations
{
    internal class ProgramDayConfiguration : IEntityTypeConfiguration<ProgramDay>
    {
        public void Configure(EntityTypeBuilder<ProgramDay> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Program)
                .WithMany(x => x.ProgramDays)
                .HasForeignKey("ProgramId")
                .IsRequired();

            builder.Ignore(x => x.MemorizingItems).Ignore(x => x.ReviewItems);
        }
    }
}
