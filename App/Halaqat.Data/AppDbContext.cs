using Halaqat.Data.Configurations;
using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Halaqat.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<AcademicQualification> AcademicQualifications { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Circle> Circles { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<ProgramDay> ProgramDays { get; set; }
        public DbSet<Sorah> Sorahs { get; set; }
        public DbSet<Verse> Verses { get; set; }
        public DbSet<ProgramDayItem> ProgramDayItems { get; set; }
        public DbSet<EducationalStage> EducationalStages { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IModelsConfigurationMarker).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
