using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Common;
using Halaqat.Shared.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Halaqat.Features.MemorizingAndReview
{
    internal partial class ViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        private readonly IMessenger _messenger;

        public ViewModel(Student student, Teacher teacher, IMediator mediator, IMessenger messenger)
        {
            ArgumentNullException.ThrowIfNull(student);
            ArgumentNullException.ThrowIfNull(teacher);
            Student = student;
            Teacher = teacher;
            _mediator = mediator;
            _messenger = messenger;
            OnPropertyChanged(nameof(Student));
            OnPropertyChanged(nameof(Teacher));

            _messenger.Register<DayItemAppreciatedMessage>(this, (r, m) =>
            {
                HasChanges = true;
                _changedDays.Add(m.ProgramDayItemViewModel);
                if (m.ProgramDayItemViewModel.CanSetMemorizingAppreciation || m.ProgramDayItemViewModel.CanSetReviewAppreciation)
                {
                    return;
                }

                int currentIndex = ProgramDays.IndexOf(m.ProgramDayItemViewModel);
                if (currentIndex >= (ProgramDays.Count - 1))
                {
                    return;
                }
                ProgramDayItemViewModel next = ProgramDays.ElementAt(currentIndex + 1);
                next.IsEnabled = true;
            });
        }

        public async Task LoadDataAsync(bool isReload = false)
        {
            using (BusyWorkRunner.CreateBusyWork(DoBusyWork))
            {
                Program program = await _mediator.Send(new Shared.Commands.Programs.GetProgram(Student.Program.Id));
                Appreciations = await _mediator.Send(new Shared.Commands.Common.GetAllCommand<Appreciation>(isReload));
                _programDayItemTypes = await _mediator.Send(new Shared.Commands.Common.GetAllCommand<ProgramDayItemType>(false));
                ProgramDays = program.ProgramDays.Select(x => new ProgramDayItemViewModel(x, _programDayItemTypes, _messenger)).ToList();
                EnableFirstProgramDayItemViewModel();
            }
        }

        private void EnableFirstProgramDayItemViewModel()
        {
            ProgramDayItemViewModel firstEnabled = ProgramDays.Where(x => x.IsEnabled).FirstOrDefault();
            foreach (ProgramDayItemViewModel item in ProgramDays)
            {
                item.IsEnabled = false;
            }
            firstEnabled.IsEnabled = true;
        }

        [RelayCommand(CanExecute = nameof(CanSave))]
        private async Task Save()
        {
            foreach (ProgramDayItemViewModel day in _changedDays)
            {
                await _mediator.Send(new CommandHandlers.UpdateProgramDay.Command(day));
            }
        }

        private bool CanSave() => HasChanges;

        public bool HasChanges
        {
            get => _hasChanges;
            private set
            {
                SetProperty(ref _hasChanges, value);
                SaveCommand.NotifyCanExecuteChanged();
            }
        }

        private bool _hasChanges;

        public Student Student { get; }
        public Teacher Teacher { get; }

        [ObservableProperty]
        private List<ProgramDayItemViewModel> _programDays;

        private List<ProgramDayItemViewModel> _changedDays = [];

        [ObservableProperty]
        private IEnumerable<Appreciation> _appreciations;

        private IEnumerable<ProgramDayItemType> _programDayItemTypes;

        public DoBusyWork DoBusyWork { get; } = new DoBusyWork();
    }
}
