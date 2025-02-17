using Halaqat.Shared.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Circles.CommandHandlers
{
    internal class ShowCircleDetailsCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Circles.ShowCircleDetailsCommand>
    {
        public async Task Handle(Shared.Commands.Circles.ShowCircleDetailsCommand request, CancellationToken cancellationToken)
        {
            Circle circle = await repository.GetById(request.Id);

            Home.CircleDetails.ViewModel viewModel = new Home.CircleDetails.ViewModel(circle);
            Home.CircleDetails.View view = new Home.CircleDetails.View(viewModel);
            view.ShowDialog();
        }
    }
}
