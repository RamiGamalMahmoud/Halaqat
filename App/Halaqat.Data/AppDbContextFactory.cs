using Microsoft.EntityFrameworkCore;

namespace Halaqat.Data
{
    public class AppDbContextFactory(string connectionString) : IAppDbContextFactory
    {
        public AppDbContext CreateAppDbContext()
        {
            return new AppDbContext(
                new DbContextOptionsBuilder()
                .UseSqlServer(connectionString)
                .Options
                );
        }
    }
}
