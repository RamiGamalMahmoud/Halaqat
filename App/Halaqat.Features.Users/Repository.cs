using Halaqat.Data;
using Halaqat.Shared;
using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Halaqat.Features.Users
{
    internal class Repository(IAppDbContextFactory dbContextFactory)
    {
        public async Task<Result<User>> GetByUserNameAndPassword(string userName, string password)
        {
            using (AppDbContext dbContext = dbContextFactory.CreateAppDbContext())
            {
                User user = await dbContext
                    .Users
                    .Where(u => u.UserName == userName)
                    .Where(x => x.Password == password)
                    .FirstOrDefaultAsync();

                return new Result<User>(user, user is not null, "");
            }
        }
    }
}
