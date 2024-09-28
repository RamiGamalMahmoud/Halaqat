using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Circles.CommandHandlers
{
    internal class ShowEditCommandHandler : IRequestHandler<Shared.Commands.Common.ShowEditModelViewCommand<Circle>>
    {
        public Task Handle(Common.ShowEditModelViewCommand<Circle> request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
