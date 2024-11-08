using Halaqat.Services;
using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.MemorizingAndReview.CommandHandlers
{
    internal class ShowMemorizationBookletReportCommandHandler(Repository repository, IMediator mediator) :
        IRequestHandler<Shared.Commands.MemorizingAndReviewCommands.ShowMemorizationBookletReportCommand>
    {
        public async Task Handle(MemorizingAndReviewCommands.ShowMemorizationBookletReportCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<ProgramDay> programDays = await repository.GetProgramDayAppreciation(request.Student);

            Dictionary<string, object> dataSource = new Dictionary<string, object>();

            dataSource.Add("ProgramDays", programDays.Select(x =>
                new
                {
                    Day = x.Day.ToString(),
                    Memorizing = ProgramDayItemService.SamorizeItems(x.MemorizingItems),
                    Review = ProgramDayItemService.SamorizeItems(x.ReviewItems),
                    Appreciations = x.ProgramDayAppreciations.Select(a => new { Name = a.Appreciation.Name, DateAppreciated = a.DateAppreciated })
                }
            ));

            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "StudentName", request.Student.Name },
                { "Program", request.Student.Program.Name }
            };

            await mediator.Send(new Shared.Commands.Common.ShowPrintCommand("MemorizationBookletReport", parameters, dataSource));
        }
    }
}
