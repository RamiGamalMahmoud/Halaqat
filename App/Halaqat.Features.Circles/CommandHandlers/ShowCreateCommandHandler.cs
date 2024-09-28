using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Circles.CommandHandlers
{
    internal class ShowCreateCommandHandler : IRequestHandler<Shared.Commands.Common.ShowCreateModelViewCommand<Circle>>
    {
        public Task Handle(Common.ShowCreateModelViewCommand<Circle> request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
