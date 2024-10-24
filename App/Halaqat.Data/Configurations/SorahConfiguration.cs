using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Halaqat.Data.Configurations
{
    internal class SorahConfiguration : IEntityTypeConfiguration<Sorah>
    {
        public void Configure(EntityTypeBuilder<Sorah> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .HasColumnType("NVARCHAR(20)")
                .IsRequired();
        }
    }
}
