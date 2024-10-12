using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Common;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading.Tasks;

namespace Halaqat.Features.Students.Home
{
    internal partial class ViewModel(IMediator mediator, IMessenger messenger) : Shared.Common.HomeViewModelBase<Student>(mediator, messenger)
    {
        public override async Task LoadDataAsync(bool isReload)
        {
            using (BusyWorkRunner.CreateBusyWork(DoBusyWork))
            {
                Models = await _mediator.Send(new Shared.Commands.Common.GetAllCommand<Student>(isReload));
            }
        }

        [RelayCommand]
        private async Task ShowStudentMemorizingAndReviewTable(Student student)
        {
            await _mediator.Send(new Shared.Commands.MemorizingAndReviewCommands.ShowMemorizingAndReviewViewCommand(student));
        }

        async partial void OnSearchTermChanged(string oldValue, string newValue)
        {
            if (newValue is null || string.IsNullOrEmpty(newValue))
            {
                await LoadDataCommand.ExecuteAsync(false);
                return;
            }
            Models = await _mediator.Send(new Shared.Commands.Students.Search(newValue));
        }

        [ObservableProperty]
        private string _searchTerm;

    }
}
