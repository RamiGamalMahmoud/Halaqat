using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared;
using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Students
{
    internal class GetAllCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Common.GetAllCommand<Student>, IEnumerable<Student>>
    {
        public async Task<IEnumerable<Student>> Handle(Common.GetAllCommand<Student> request, CancellationToken cancellationToken)
        {
            return await repository.GetAll(request.Reload);
        }
    }

    internal class ShowCreateStudent(IServiceProvider services) : IRequestHandler<Shared.Commands.Common.ShowCreateModelViewCommand<Student>>
    {
        public Task Handle(Common.ShowCreateModelViewCommand<Student> request, CancellationToken cancellationToken)
        {
            IMediator mediator = services.GetRequiredService<IMediator>();
            IMessenger messenger = services.GetRequiredService<IMessenger>();
            Editor.CreateViewModel viewModel = new Editor.CreateViewModel(mediator, messenger);
            Editor.View view = new Editor.View(viewModel, messenger);
            view.ShowDialog();
            return Task.CompletedTask;
        }
    }

    internal class CreateStudentCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Common.CreateModelCommand<Student, StudentDataModel>, Result<Student>>
    {
        public async Task<Result<Student>> Handle(Common.CreateModelCommand<Student, StudentDataModel> request, CancellationToken cancellationToken)
        {
            return await repository.Create(request.DataModel);
        }
    }

    internal class ShowEditStudentCommandHandler(IServiceProvider services) : IRequestHandler<Shared.Commands.Common.ShowEditModelViewCommand<Student>>
    {
        public Task Handle(Common.ShowEditModelViewCommand<Student> request, CancellationToken cancellationToken)
        {
            IMediator mediator = services.GetRequiredService<IMediator>();
            IMessenger messenger = services.GetRequiredService<IMessenger>();
            Editor.UpdateViewModel viewModel = new Editor.UpdateViewModel(mediator, messenger, request.Model);
            Editor.View view = new Editor.View(viewModel, messenger);
            view.ShowDialog();
            return Task.CompletedTask;
        }
    }

    internal class UpdateStudentCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Common.UpdateModelCommand<StudentDataModel>, Result>
    {
        public async Task<Result> Handle(Common.UpdateModelCommand<StudentDataModel> request, CancellationToken cancellationToken)
        {
            return await repository.Update(request.DataModel);
        }
    }

    internal class RemoveStudentCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Common.RemoveModelCommand<Student>, Result>
    {
        public async Task<Result> Handle(Common.RemoveModelCommand<Student> request, CancellationToken cancellationToken)
        {
            return await repository.Remove(request.Model);
        }
    }

    internal class SearchCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Students.Search, IEnumerable<Student>>
    {
        public async Task<IEnumerable<Student>> Handle(Shared.Commands.Students.Search request, CancellationToken cancellationToken)
        {
            return await repository.GetByName(request.Name);
        }
    }
}
