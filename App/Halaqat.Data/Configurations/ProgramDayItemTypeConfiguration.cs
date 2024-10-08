using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Halaqat.Data.Configurations
{
    internal class ProgramDayItemTypeConfiguration : IEntityTypeConfiguration<ProgramDayItemType>
    {
        public void Configure(EntityTypeBuilder<ProgramDayItemType> builder)
        {
            builder.ToTable("ProgramItemTypes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("NVARCHAR(20)").IsRequired();

            builder.HasData(new[]
            {
                new { Id = 1, Name = "حفظ" },
                new { Id = 2, Name = "مراجعة" },
            });
        }
    }
}
