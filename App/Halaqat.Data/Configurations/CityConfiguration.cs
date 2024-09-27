using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Halaqat.Data.Configurations
{
    internal class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasColumnType("NVARCHAR(20)");

            builder.HasIndex(x => x.Name).IsUnique();

#if DEBUG
            builder.HasData(
                [
                new { Id = 1, Name = "مدينة 1"},
                new { Id = 2, Name = "مدينة 2"},
                new { Id = 3, Name = "مدينة 3"},
                ]);
#endif 
        }
    }
}
