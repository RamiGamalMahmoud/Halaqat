using Halaqat.Services;
using Halaqat.Shared.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.CommandHandlers
{
    internal class ConfirmRequestHandler(ConfirmationService confirmationService) : IRequestHandler<Shared.Commands.Common.ConfirmCommand, bool>
    {
        public Task<bool> Handle(Common.ConfirmCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult( confirmationService.Confirm(request.Message));
        }
    }
}
