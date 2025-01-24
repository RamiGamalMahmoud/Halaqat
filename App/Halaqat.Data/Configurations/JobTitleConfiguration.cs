using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Halaqat.Data.Configurations
{
    internal class JobTitleConfiguration : IEntityTypeConfiguration<JobTitle>
    {
        public void Configure(EntityTypeBuilder<JobTitle> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("NVARCHAR(20)");

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.HasData(
            [
                new { Id = 1, Name = "معلم", DateCreated = DateTime.Parse("2024-01-01") },
                new { Id = 2, Name = "إداري", DateCreated = DateTime.Parse("2024-01-02") },
                new { Id = 3, Name = "معلمة", DateCreated = DateTime.Parse("2024-01-01") },
                new { Id = 4, Name = "إدارية", DateCreated = DateTime.Parse("2024-01-01") },
                new { Id = 5, Name = "مشرف", DateCreated = DateTime.Parse("2024-01-01") },
                new { Id = 6, Name = "مشرفة", DateCreated = DateTime.Parse("2024-01-01") },
            ]);
        }
    }
}
