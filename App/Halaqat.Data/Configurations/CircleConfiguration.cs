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
            builder.Property(x => x.Name).HasColumnType("varchar(50)").IsRequired();
        }
    }
}
