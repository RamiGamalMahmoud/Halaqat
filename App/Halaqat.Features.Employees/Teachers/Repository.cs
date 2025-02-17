using Halaqat.Data;
using Halaqat.Shared;
using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Halaqat.Features.Employees.Teachers
{
    internal class Repository(IAppDbContextFactory dbContextFactory) : RepositoryBase<Teacher, EmployeeViewModel>(dbContextFactory)
    {
        public override async Task<Result<Teacher>> Create(EmployeeViewModel dataModel)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                User user = null;
                if (dataModel.UserName is not null && dataModel.Password is not null)
                {
                    user = new User()
                    {
                        UserName = dataModel.UserName,
                        Password = dataModel.Password,
                        DateCreated = dataModel.DateCreated,
                        IsActive = true
                    };
                }

                Teacher teacher = new Teacher()
                {
                    Name = dataModel.Name,
                    DateCreated = dataModel.DateCreated,
                    AcademicQualificationId = dataModel.AcademicQualification.Id,
                    JobTitleId = dataModel.JobTitle.Id,
                    Address = new Address()
                    {
                        CityId = dataModel.City.Id,
                        District = dataModel.District,
                        Street = dataModel.Street
                    },
                    User = user
                };

                foreach (Phone phone in dataModel.Phones)
                {
                    teacher.Phones.Add(phone);
                }

                dbContext.Teachers.Add(teacher);
                await dbContext.SaveChangesAsync();

                dataModel.UpdateModel(teacher);

                _entities?.Add(teacher);
                return new Result<Teacher>(teacher, true, null);
            }
        }

        public override async Task<IEnumerable<Teacher>> GetAll(bool reload)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                if (!_isLoaded || reload)
                {
                    IEnumerable<Teacher> teachers = await dbContext
                        .Teachers
                        .Include(x => x.AcademicQualification)
                        .Include(x => x.JobTitle)
                        .Include(x => x.Address)
                        .ThenInclude(x => x.City)
                        .Include(x => x.Phones)
                        .Include(x => x.Circles).ThenInclude(c => c.Students)
                        .Where(x => !x.IsDeleted)
                        .ToListAsync();
                    SetEntities(teachers);
                }
                return _entities;
            }
        }

        public async Task<Result<Teacher>> GetLoggedInTeacher(int userId)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                Teacher teacher = await dbContext
                    .Teachers
                    .Include(x => x.Circles)
                        .ThenInclude(c => c.Students)
                        .ThenInclude(s => s.Program)
                    .Include(x => x.Circles)
                        .ThenInclude(c => c.Students)
                        .ThenInclude(s => s.EducationalStage)
                    .Include(x => x.Circles)
                        .ThenInclude(c => c.Students)
                        .ThenInclude(s  => s.Class)
                    .Include(x => x.Circles)
                        .ThenInclude(c => c.Students)
                        .ThenInclude(s => s.Address)
                    .Where(x => x.User.Id == userId)
                    .FirstOrDefaultAsync();

                if(teacher is null)
                {
                    return new Result<Teacher>(null, false, "المستخدم ليس معلم");
                }

                return new Result<Teacher>(teacher, true, null);
            }
        }


        public override Task<Result> Remove(Teacher circle)
        {
            throw new System.NotImplementedException();
        }

        public override Task<Result> Update(EmployeeViewModel dataModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
