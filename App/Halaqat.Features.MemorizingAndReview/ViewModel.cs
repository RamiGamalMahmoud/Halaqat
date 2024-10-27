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
                ChangedDays.Add(m.ProgramDayItemViewModel);

                if (m.ProgramDayItemViewModel.ProgramDayMemorizingItemViewModel.CanInsertAppreciation ||
                    m.ProgramDayItemViewModel.ProgramDayReviewItemViewModel.CanInsertAppreciation)
                {
                    return;
                }

                int currentIndex = ProgramDays.IndexOf(m.ProgramDayItemViewModel);

                ProgramDayViewModel next = ProgramDays.ElementAt(currentIndex + 1);
                next.IsEnabled = true;
            });
        }

        public async Task LoadDataAsync(bool isReload = false)
        {
            using (BusyWorkRunner.CreateBusyWork(DoBusyWork))
            {
                Appreciations = await _mediator.Send(new Shared.Commands.Common.GetAllCommand<Appreciation>(isReload));
                _programDayItemTypes = await _mediator.Send(new Shared.Commands.Common.GetAllCommand<ProgramDayItemType>(false));

                ProgramDays = (await _mediator.Send(new CommandHandlers.GetStudentAppreciatinos.Command(Student.Id)))
                    .Select(x => new ProgramDayViewModel(x, Student, Teacher, _programDayItemTypes, _messenger)).ToList();
                EnableFirstProgramDayItemViewModel();
            }
        }

        private void EnableFirstProgramDayItemViewModel()
        {
            ProgramDayViewModel firstEnabled = ProgramDays.Where(x => x.IsEnabled).FirstOrDefault();
            foreach (ProgramDayViewModel item in ProgramDays)
            {
                item.IsEnabled = false;
            }
            if (firstEnabled is not null) firstEnabled.IsEnabled = true;
        }

        [RelayCommand(CanExecute = nameof(CanSave))]
        private async Task Save()
        {
            foreach (ProgramDayViewModel day in ChangedDays)
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
        private List<ProgramDayViewModel> _programDays;

        public List<ProgramDayViewModel> ChangedDays { get; } = [];

        [ObservableProperty]
        private IEnumerable<Appreciation> _appreciations;

        private IEnumerable<ProgramDayItemType> _programDayItemTypes;

        public DoBusyWork DoBusyWork { get; } = new DoBusyWork();
    }
}
