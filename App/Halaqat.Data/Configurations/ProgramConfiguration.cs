using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Halaqat.Data.Configurations
{
    internal class ProgramConfiguration : IEntityTypeConfiguration<Program>
    {
        public void Configure(EntityTypeBuilder<Program> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasColumnType("NVARCHAR(50)");

            builder.Property(x => x.Notes).HasColumnType("NVARCHAR(MAX)").IsRequired(false);

            builder.HasData(new { Id = 1, Name = "برنامج الـ 612 يوم", ExpectedDuration = 612 });
        }
    }
}
