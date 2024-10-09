using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Halaqat.Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserName)
                .HasColumnType("NVARCHAR(20)")
                .IsRequired();

            builder.Property(x => x.Password)
                .HasColumnType("NVARCHAR(20)")
                .IsRequired();

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.HasIndex(x => x.UserName)
                .IsUnique();

            builder.HasData(new { Id = 1, DateCreated = DateTime.Parse("2024-01-01"), UserName = "admin", Password = "admin", IsActive = true });
        }
    }
}
