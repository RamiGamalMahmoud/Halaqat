using Halaqat.Data;
using Halaqat.Shared;
using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Halaqat.Features.Students
{
    internal class Repository(IAppDbContextFactory dbContextFactory) : RepositoryBase<Student, StudentDataModel>(dbContextFactory)
    {
        public async Task<IEnumerable<EducationalStage>> GetEducationalStagesAsync()
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                return await dbContext
                    .EducationalStages
                    .Include(x => x.Classes)
                    .ToListAsync();
            }
        }

        public async Task<IEnumerable<Class>> GetClassAsync()
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                return await dbContext
                    .Classes
                    .Include(x => x.EducationalStage)
                    .ToListAsync();
            }
        }

        public override async Task<IEnumerable<Student>> GetAll(bool reload)
        {
            if (!_isLoaded || reload)
            {
                using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
                {
                    IEnumerable<Student> students = await dbContext.Students
                        .Include(x => x.Address)
                        .ThenInclude(x => x.City)
                        .Include(x => x.Phones)
                        .Include(x => x.Circle)
                        .ThenInclude(x => x.Teacher)
                        .Include(x => x.Program)
                        .Include(x => x.EducationalStage)
                        .Include(x => x.Class)
                        .Where(x => !x.IsDeleted)
                        .OrderBy(x => x.Name)
                        .ToListAsync();

                    SetEntities(students);
                }

            }
            return _entities;
        }

        public async Task<IEnumerable<Student>> GetStudentsWithNoCircle()
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                return await dbContext
                    .Students
                    .Where(x => !x.IsDeleted)
                    .Where(x => x.Circle == null).ToListAsync();
            }
        }

        public async Task<IEnumerable<Student>> GetByName(string name)
        {
            if (_entities is not null)
            {
                return _entities.Where(x => x.Name.Contains(name));
            }

            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                IEnumerable<Student> students = await dbContext
                    .Students
                    //.Include(x => x.Gender)
                    .Include(x => x.Address)
                    .ThenInclude(x => x.City)
                    .Include(x => x.Circle)
                    .Include(x => x.Phones)
                    .Where(x => !x.IsDeleted)
                    .Where(x => x.Name.Contains(name))
                    .ToArrayAsync();

                return students;
            }
        }

        public override async Task<Result<Student>> Create(StudentDataModel dataModel)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                Address studentAddress = new Address()
                {
                    CityId = dataModel.City.Id,
                    District = dataModel.District,
                    Street = dataModel.Street
                };

                Student student = Activator.CreateInstance(typeof(Student), true) as Student;
                student.Name = dataModel.Name;
                //student.DateOfBirth = (DateTime)dataModel.DateOfBirth;
                student.DateCreated = dataModel.DateCreated;
                //student.GenderId = dataModel.Gender.Id;
                student.Address = studentAddress;
                student.CircleId = dataModel.Circle?.Id;
                student.ProgramId = dataModel.Program?.Id;
                dbContext.Entry(student).Property<int?>("EducationalStageId").CurrentValue = dataModel.EducationalStage?.Id;
                dbContext.Entry(student).Property<int?>("ClassId").CurrentValue = dataModel.Class?.Id;

                foreach (Phone phone in dataModel.Phones)
                {
                    student.Phones.Add(phone);
                }

                dbContext.Students.Add(student);
                await dbContext.SaveChangesAsync();
                dataModel.UpdateModel(student);

                _entities.Add(student);
                return new Result<Student>(student, true, null);
            }
        }

        public override async Task<Result> Update(StudentDataModel dataModel)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                Address address = await dbContext.Addresses.FindAsync(dataModel.Address.Id);

                IEnumerable<int> phonesIds = dataModel.Phones.Select(x => x.Id).Where(x => x > 0);
                IEnumerable<Phone> newPhones = dataModel.Phones.Where(x => x.Id == 0);
                IEnumerable<Phone> oldPhones = dbContext.Set<Phone>().Where(x => phonesIds.Contains(x.Id));
                IEnumerable<Phone> phones = newPhones.Concat(oldPhones);

                Student stored = await dbContext.Students.FindAsync(dataModel.Model.Id);
                await dbContext.Entry(stored).Collection(x => x.Phones).LoadAsync();

                address.CityId = dataModel.City.Id;
                address.District = dataModel.District;
                address.Street = dataModel.Street;

                stored.Phones.Clear();
                foreach (Phone phone in phones)
                {
                    stored.Phones.Add(phone);
                }

                stored.Name = dataModel.Name;
                //stored.GenderId = dataModel.Gender.Id;
                //stored.DateOfBirth = (DateTime)dataModel.DateOfBirth;
                stored.CircleId = dataModel.Circle.Id;
                stored.ProgramId = dataModel.Program?.Id;
                stored.DateCreated = dataModel.DateCreated;
                dbContext.Entry(stored).Property<int?>("EducationalStageId").CurrentValue = dataModel.EducationalStage?.Id;
                dbContext.Entry(stored).Property<int?>("ClassId").CurrentValue = dataModel.Class?.Id;

                dbContext.Students.Update(stored);
                await dbContext.SaveChangesAsync();
                dataModel.UpdateModel(dataModel.Model);
            }

            return await Task.FromResult(Result.Success);
        }

        public override async Task<Result> Remove(Student student)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                Student stored = await dbContext.Students.FindAsync(student.Id);
                stored.Delete();
                await dbContext.SaveChangesAsync();
                _entities.Remove(student);
                return Result.Success;
            }
        }
    }
}
