using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Halaqat.Data.Configurations
{
    internal class AppreciationConfiguration : IEntityTypeConfiguration<Appreciation>
    {
        public void Configure(EntityTypeBuilder<Appreciation> builder)
        {
            builder.ToTable("Appreciations");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("NVARCHAR(10)");

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasData(new[]
            {
                new { Id = 1, Name = "إعادة" },
                new { Id = 2, Name = "جيد" },
                new { Id = 3, Name = "جيد جدا" },
                new { Id = 4, Name = "ممتاز" },
            } );
        }
    }
}
