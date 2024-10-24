using CommunityToolkit.Mvvm.ComponentModel;
using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Halaqat.Features.Management.Cities.Home
{
    internal partial class ViewModel(IMediator mediator) : ObservableObject
    {
        public async Task LoadDataAsync(bool reload)
        {
            Cities = await mediator.Send(new Shared.Commands.Common.GetAllCommand<City>(reload));
        }

        [ObservableProperty]
        private IEnumerable<City> _cities;

    }
}
