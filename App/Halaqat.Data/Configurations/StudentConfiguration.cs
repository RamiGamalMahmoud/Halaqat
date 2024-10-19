using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Halaqat.Data.Configurations
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("NVARCHAR(50)");

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            builder.Property(x => x.DateCreated).IsRequired();

            builder.HasOne(x => x.Address)
                .WithMany()
                .IsRequired()
                .HasForeignKey(x => x.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Gender)
                .WithMany()
                .HasForeignKey(x => x.GenderId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Phones)
                .WithMany();

            builder.HasOne(x => x.Program)
                .WithMany()
                .HasForeignKey(x => x.ProgramId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.EducationalStage)
                .WithMany()
                .HasForeignKey("EducationalStageId")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Class)
                .WithMany()
                .HasForeignKey("ClassId")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
