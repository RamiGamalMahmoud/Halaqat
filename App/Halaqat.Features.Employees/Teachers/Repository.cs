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
                Teacher teacher = new Teacher()
                {
                    Name = dataModel.Name,
                    DateCreated = dataModel.DateCreated,
                    AcademicQualificationId = dataModel.AcademicQualification.Id,
                    JobTitleId = dataModel.JobTitle.Id,
                    GenderId = dataModel.Gender.Id,
                    Address = new Address()
                    {
                        CityId = dataModel.City.Id,
                        District = dataModel.District,
                        Street = dataModel.Street
                    }
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
                        .Include(x => x.Gender)
                        .Include(x => x.AcademicQualification)
                        .Include(x => x.JobTitle)
                        .Include(x => x.Address)
                        .ThenInclude(x => x.City)
                        .Include(x => x.Phones)
                        .Include(x => x.Circles)
                        .Where(x => !x.IsDeleted)
                        .ToListAsync();
                    SetEntities(teachers);
                }
                return _entities;
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
