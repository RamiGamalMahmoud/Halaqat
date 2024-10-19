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

            builder.HasOne(x => x.ProgramDay)
                .WithMany(x => x.ProgramDayAppreciations)
                .HasForeignKey($"{nameof(ProgramDay)}Id");

            builder.HasOne(x => x.Appreciation)
                .WithMany()
                .HasForeignKey($"{nameof(Appreciation)}Id");
        }
    }
}
