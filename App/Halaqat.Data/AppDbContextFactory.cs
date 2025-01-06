using Halaqat.Shared.Common;
using Microsoft.EntityFrameworkCore;

namespace Halaqat.Data
{
    public class AppDbContextFactory(ConnectionStringFactory connectionStringFactory) : IAppDbContextFactory
    {
        public AppDbContext CreateAppDbContext()
        {
            return new AppDbContext(
                new DbContextOptionsBuilder()
                .UseSqlServer(connectionStringFactory.WithDatabase().GetConnectionString())
                .Options
                );
        }

        public AppDbContext CreateAppDbContextWithoutDatabase()
        {
            return new AppDbContext(
                new DbContextOptionsBuilder()
                .UseSqlServer(connectionStringFactory.WithDatabase(false).GetConnectionString())
                .Options
                );
        }
    }
}
