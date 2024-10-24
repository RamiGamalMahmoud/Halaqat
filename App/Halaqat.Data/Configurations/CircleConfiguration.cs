using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Halaqat.Data.Configurations
{
    internal class CircleConfiguration : IEntityTypeConfiguration<Circle>
    {
        public void Configure(EntityTypeBuilder<Circle> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("NVARCHAR(50)").IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.Students).WithOne(x => x.Circle).HasForeignKey(x => x.CircleId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
