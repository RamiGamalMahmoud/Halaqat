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

            builder.Ignore(x => x.HasFullPrivileges);

            builder.OwnsOne(x => x.UsersManagementPrivileges, p =>
            {
                p.Property(x => x.CanCreate).HasDefaultValue(false);
                p.Property(x => x.CanRead).HasDefaultValue(false);
                p.Property(x => x.CanDelete).HasDefaultValue(false);
                p.Property(x => x.CanUpdate).HasDefaultValue(false);
                p.Ignore(x => x.HasFullPrivileges);
            });

            builder.OwnsOne(x => x.EmployeesManagementPrivileges, p =>
            {
                p.Property(x => x.CanCreate).HasDefaultValue(false);
                p.Property(x => x.CanRead).HasDefaultValue(false);
                p.Property(x => x.CanDelete).HasDefaultValue(false);
                p.Property(x => x.CanUpdate).HasDefaultValue(false);
                p.Ignore(x => x.HasFullPrivileges);
            });

            builder.OwnsOne(x => x.StudentsManagementPrivileges, p =>
            {
                p.Property(x => x.CanCreate).HasDefaultValue(false);
                p.Property(x => x.CanRead).HasDefaultValue(false);
                p.Property(x => x.CanDelete).HasDefaultValue(false);
                p.Property(x => x.CanUpdate).HasDefaultValue(false);
                p.Ignore(x => x.HasFullPrivileges);
            });

            builder.OwnsOne(x => x.CirclesManagementPrivileges, p =>
            {
                p.Property(x => x.CanCreate).HasDefaultValue(false);
                p.Property(x => x.CanRead).HasDefaultValue(false);
                p.Property(x => x.CanDelete).HasDefaultValue(false);
                p.Property(x => x.CanUpdate).HasDefaultValue(false);
                p.Ignore(x => x.HasFullPrivileges);
            });

            builder.OwnsOne(x => x.ProgramsManagementPrivileges, p =>
            {
                p.Property(x => x.CanCreate).HasDefaultValue(false);
                p.Property(x => x.CanRead).HasDefaultValue(false);
                p.Property(x => x.CanDelete).HasDefaultValue(false);
                p.Property(x => x.CanUpdate).HasDefaultValue(false);
                p.Ignore(x => x.HasFullPrivileges);
            });

            builder.OwnsOne(x => x.ReportsManagementPrivileges, p =>
            {
                p.Property(x => x.CanCreate).HasDefaultValue(false);
                p.Property(x => x.CanRead).HasDefaultValue(false);
                p.Property(x => x.CanDelete).HasDefaultValue(false);
                p.Property(x => x.CanUpdate).HasDefaultValue(false);
                p.Ignore(x => x.HasFullPrivileges);
            });

            builder.HasData(new
            {
                Id = 1,
                DateCreated = DateTime.Parse("2024-01-01"),
                UserName = "admin",
                Password = "admin",
                IsActive = true,
                IsSuperAdmin = true
            });
        }
    }
}
