using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared;
using Halaqat.Shared.Common;
using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Halaqat.Features.Circles.Editor
{
    internal class UpdateViewModel(IMediator mediator, IMessenger messenger, Circle model) : ViewModel(mediator, messenger, model)
    {
        public override async Task LoadDataAsync()
        {
            Teachers = await _mediator.Send(new Shared.Commands.Common.GetAllCommand<Teacher>(false));

            IEnumerable<SelectableObject<Student>> studentsWithNoCircle = (await _mediator.Send(new Shared.Commands.Students.GetStudentsWithNoCircleCommand()))
                .Select(x => new SelectableObject<Student>(x, false, StudentsChanged))
                .ToList();

            Students = studentsWithNoCircle
                .Concat(DataModel.Students.Select(x => new SelectableObject<Student>(x, true, StudentsChanged))).ToList();
        }

        protected override async Task Save()
        {
            IEnumerable<Student> students = Students.Where(x => x.IsSelected)
                .Select(x => x.Value)
                .ToList();

            DataModel.Students.Clear();

            foreach (Student student in students)
            {
                DataModel.Students.Add(student);
            }

            Result result = await _mediator.Send(new Shared.Commands.Common.UpdateModelCommand<CircleDataModel>(DataModel));

            if (result.IsSuccess)
            {
                _messenger.Send(new Shared.Messages.Common.EntityUpdatedMessage<Circle>());
                _messenger.Send(new Shared.Messages.Notifications.SuccessNotification());
            }
            else
            {
                _messenger.Send(new Shared.Messages.Notifications.FailureNotification());
            }
        }
    }
}
