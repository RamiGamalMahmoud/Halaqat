using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared;
using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Halaqat.Features.Circles.Editor
{
    internal class CreateViewModel(IMediator mediator, IMessenger messenger) : ViewModel(mediator, messenger, null)
    {
        protected override async Task Save()
        {
            IEnumerable<Student> students = Students.Where(x => x.IsSelected).Select(x => x.Value).ToList();

            foreach (Student student in students)
            {
                DataModel.Students.Add(student);
            }

            Result<Circle> result = await _mediator.Send(new Shared.Commands.Common.CreateModelCommand<Circle, CircleDataModel>(DataModel));

            if (result.IsSuccess)
            {
                _messenger.Send(new Shared.Messages.Common.EntityCreatedMessage<Circle>(result.Value));
                _messenger.Send(new Shared.Messages.Notifications.SuccessNotification());
            }
            else
            {
                _messenger.Send(new Shared.Messages.Notifications.FailureNotification());
            }
        }
    }
}
