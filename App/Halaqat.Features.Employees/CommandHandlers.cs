using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Data;
using Halaqat.Features.Employees.Editor;
using Halaqat.Shared;
using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Employees
{
    internal class GetAllCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Common.GetAllCommand<Employee>, IEnumerable<Employee>>
    {
        public async Task<IEnumerable<Employee>> Handle(Common.GetAllCommand<Employee> request, CancellationToken cancellationToken)
        {
            return await repository.GetAll(request.Reload);
        }
    }

    internal class GetAllJobTitlesCommandHandler(IAppDbContextFactory dbContextFactory) : IRequestHandler<Shared.Commands.Common.GetAllCommand<JobTitle>, IEnumerable<JobTitle>>
{
        public async Task<IEnumerable<JobTitle>> Handle(Common.GetAllCommand<JobTitle> request, CancellationToken cancellationToken)
        {
            using (AppDbContext dbContext = dbContextFactory.CreateAppDbContext())
            {
                return await dbContext.JobTitles.ToListAsync();
            }
        }
    }

    internal class GetAllCitiesCommandHandler(IAppDbContextFactory dbContextFactory) : IRequestHandler<Shared.Commands.Common.GetAllCommand<City>, IEnumerable<City>>
{
        public async Task<IEnumerable<City>> Handle(Common.GetAllCommand<City> request, CancellationToken cancellationToken)
        {
            using (AppDbContext dbContext = dbContextFactory.CreateAppDbContext())
            {
                return await dbContext.Cities.ToListAsync();
            }
        }
    }

    internal class GetAllAcademicQualificationsCommandHandler(IAppDbContextFactory dbContextFactory) : IRequestHandler<Shared.Commands.Common.GetAllCommand<AcademicQualification>, IEnumerable<AcademicQualification>>
    {
        public async Task<IEnumerable<AcademicQualification>> Handle(Common.GetAllCommand<AcademicQualification> request, CancellationToken cancellationToken)
        {
            using (AppDbContext dbContext = dbContextFactory.CreateAppDbContext())
            {
                return await dbContext.AcademicQualifications.ToListAsync();
            }
        }
    }

    internal class ShowCreateEmployeeView(IServiceProvider services) : IRequestHandler<Shared.Commands.Common.ShowCreateModelViewCommand<Employee>>
    {
        public Task Handle(Common.ShowCreateModelViewCommand<Employee> request, CancellationToken cancellationToken)
        {
            IMessenger messenger = services.GetRequiredService<IMessenger>();
            EditorViewModelBase viewModel = services.GetRequiredService<Editor.CreateViewModel>();
            Editor.View view = new Editor.View(viewModel, messenger);
            view.ShowDialog();
            return Task.CompletedTask;
        }
    }

    internal class ShowEditEmployeeViewCommandHandler(IServiceProvider services) : IRequestHandler<Shared.Commands.Common.ShowEditModelViewCommand<Employee>>
    {
        public Task Handle(Common.ShowEditModelViewCommand<Employee> request, CancellationToken cancellationToken)
        {
            IMediator mediator = services.GetRequiredService<IMediator>();
            IMessenger messenger = services.GetRequiredService<IMessenger>();
            EditorViewModelBase viewModel = new UpdateViewModel(mediator, messenger, request.Model);
            Editor.View view = new Editor.View(viewModel, messenger);
            view.ShowDialog();
            return Task.CompletedTask;
        }
    }

    internal class CreateEmployeeCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Common.CreateModelCommand<Employee, EmployeeViewModel>, Result<Employee>>
    {
        public async Task<Result<Employee>> Handle(Common.CreateModelCommand<Employee, EmployeeViewModel> request, CancellationToken cancellationToken)
        {
            return await repository.Create(request.DataModel);
        }
    }

    internal class UpdateEmployeeCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Common.UpdateModelCommand<EmployeeViewModel>, Result>
    {
        public async Task<Result> Handle(Common.UpdateModelCommand<EmployeeViewModel> request, CancellationToken cancellationToken)
        {
            return await repository.Update(request.DataModel);
        }
    }

    internal class RemoveEmployeeCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Common.RemoveModelCommand<Employee>, Result>
    {
        public async Task<Result> Handle(Common.RemoveModelCommand<Employee> request, CancellationToken cancellationToken)
        {
            return await repository.Remove(request.Model);
        }
    }

    internal class GetEmployeesByNameCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Employees.GetByName, IEnumerable<Employee>>
    {
        public async Task<IEnumerable<Employee>> Handle(Shared.Commands.Employees.GetByName request, CancellationToken cancellationToken)
        {
            return await repository.GetByName(request.Name);
        }
    }
}
