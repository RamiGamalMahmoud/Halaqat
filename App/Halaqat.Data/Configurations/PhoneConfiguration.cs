using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Halaqat.Data.Configurations
{
    internal class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Phone> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Number)
                .IsRequired()
                .HasColumnType("NVARCHAR(14)");
        }
    }
}
