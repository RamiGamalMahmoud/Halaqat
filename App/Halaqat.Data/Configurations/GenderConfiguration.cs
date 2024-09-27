using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Halaqat.Data.Configurations
{
    internal class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasColumnType("NVARCHAR(5)");

            builder.HasData(new[]
            {
                new { Id = 1, Name = "ذكر" },
                new { Id = 2, Name = "أنثى" }
            });
        }
    }
}
