using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Halaqat.Data.Configurations
{
    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Street)
                .IsRequired()
                .HasColumnType("NVARCHAR(50)");

            builder.HasOne(x => x.City)
                .WithMany()
                .HasForeignKey($"{nameof(City)}Id")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

        }
    }
}
