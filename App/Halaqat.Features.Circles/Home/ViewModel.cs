using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Common;
using Halaqat.Shared.Models;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using static Halaqat.Shared.Messages.Users;

namespace Halaqat.Features.Circles.Home
{
    internal partial class ViewModel : HomeViewModelBase<Circle>
    {
        public ViewModel(IMediator mediator, IMessenger messenger) : base(mediator, messenger)
        {
            Privileges = _messenger.Send(new GetCirclesPrivilegesRequestMessage());
        }
        public override async Task LoadDataAsync(bool isReload)
        {
            using (BusyWorkRunner.CreateBusyWork(DoBusyWork))
            {
                await Task.Delay(5000);
                _all = await _mediator.Send(new Shared.Commands.Common.GetAllCommand<Circle>(isReload));
                Models = _all;
            }
        }

        protected override void OnSearch()
        {
            Models = string.IsNullOrEmpty(SearchTerm) ? _all : _all.Where(x => x.Name.Contains(SearchTerm));
        }
    }
}
