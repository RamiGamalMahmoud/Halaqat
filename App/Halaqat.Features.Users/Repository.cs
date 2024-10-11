using Halaqat.Data;
using Halaqat.Shared;
using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Halaqat.Features.Users
{
    internal class Repository(IAppDbContextFactory dbContextFactory) : RepositoryBase<User, UserDataModel>(dbContextFactory)
    {
        public override Task<Result<User>> Create(UserDataModel dataModel)
        {
            throw new System.NotImplementedException();
        }

        public override async Task<IEnumerable<User>> GetAll(bool reload)
        {
            if (!_isLoaded || reload)
            {
                using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
                {
                    IEnumerable<User> users = await dbContext
                        .Users
                        .Where(x => x.IsActive)
                        .ToListAsync();
                    SetEntities(users);
                }
            }

            return _entities;
        }

        public async Task<Result<User>> GetByUserNameAndPassword(string userName, string password)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                User user = await dbContext
                    .Users
                    .Where(x => x.UserName == userName && x.Password == password)
                    .FirstOrDefaultAsync();

                return new Result<User>(user, user is not null, "");
            }
        }

        public override async Task<Result> Remove(User model)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                User stored = await dbContext
                    .Users
                    .Where(x => x.Id == model.Id)
                    .FirstOrDefaultAsync();

                if (stored is null)
                {
                    return new Result("User is not exitsts in database");
                }
                stored.IsActive = false;
                stored.UsersManagementPrivileges.HasFullPrivileges = false;
                dbContext.Users.Update(stored);

                try
                {
                    await dbContext.SaveChangesAsync();
                    return Result.Success;
                }
                catch (System.Exception)
                {
                    return new Result("Can not update selected user");
                }
            }
        }

        public override async Task<Result> Update(UserDataModel dataModel)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                User stored = await dbContext
                    .Users
                    .Where(x => x.Id == dataModel.Model.Id)
                    .FirstOrDefaultAsync();

                if(stored is null)
                {
                    return new Result("User is not exitsts in database");
                }

                stored.UserName = dataModel.UserName;
                stored.Password = dataModel.Password;
                stored.IsActive = dataModel.IsActive;

                stored.UsersManagementPrivileges.UpdateFrom(dataModel.UsersManagementPrivileges);
                stored.EmployeesManagementPrivileges.UpdateFrom(dataModel.EmployeesManagementPrivileges);
                stored.StudentsManagementPrivileges.UpdateFrom(dataModel.StudentsManagementPrivileges);
                stored.CirclesManagementPrivileges.UpdateFrom(dataModel.CirclesManagementPrivileges);
                stored.ProgramsManagementPrivileges.UpdateFrom(dataModel.ProgramsManagementPrivileges);
                stored.ReportsManagementPrivileges.UpdateFrom(dataModel.ReportsManagementPrivileges);

                dbContext.Users.Update(stored);

                try
                {
                    await dbContext.SaveChangesAsync();
                    dataModel.Update();
                    return Result.Success;
                }
                catch (System.Exception)
                {
                    return new Result("Can not update selected user");
                }
            }
        }
    }
}
