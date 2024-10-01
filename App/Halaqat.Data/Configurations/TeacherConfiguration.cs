using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Halaqat.Data.Configurations
{
    internal class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers");

            builder.HasMany(x => x.Circles).WithOne(x => x.Teacher).HasForeignKey(x => x.TeacherId).OnDelete(DeleteBehavior.Restrict).IsRequired(false);
        }
    }
}
