using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Halaqat.Data
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<AppDbContext> builder = new DbContextOptionsBuilder<AppDbContext>();
            builder
                .UseSqlServer(@"
Server=.\SQLEXPRESS2019;
Integrated Security=SSPI;
Initial Catalog=halaqat;
TrustServerCertificate=True;
Trusted_Connection=True;");

            AppDbContext dbContext = new AppDbContext(builder.Options);
            return dbContext;
        }
    }
}
