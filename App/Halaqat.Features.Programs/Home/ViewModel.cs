using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Common;
using Halaqat.Shared.Models;
using MediatR;
using System.Linq;
using System.Threading.Tasks;

namespace Halaqat.Features.Programs.Home
{
    internal class ViewModel : HomeViewModelBase<Program>
    {
        public ViewModel(IMediator mediator, IMessenger messenger) : base(mediator, messenger)
        {
            Privileges = _messenger.Send(new Shared.Messages.Users.GetProgramsPrivilegesRequestMessage());
        }
        public override async Task LoadDataAsync(bool isReload)
        {
            _all = await _mediator.Send(new Shared.Commands.Common.GetAllCommand<Program>(isReload));
            Models = _all;
        }

        protected override void OnSearch()
        {
            Models = string.IsNullOrEmpty(SearchTerm) ? _all : _all.Where(x => x.Name.Contains(SearchTerm));
        }
    }
}
