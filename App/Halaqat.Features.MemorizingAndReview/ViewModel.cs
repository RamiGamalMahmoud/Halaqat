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

        public ViewModel(Student student, Teacher teacher, IMediator mediator, IMessenger messenger)
        {
            ArgumentNullException.ThrowIfNull(student);
            ArgumentNullException.ThrowIfNull(teacher);
            Student = student;
            Teacher = teacher;
            _mediator = mediator;
            OnPropertyChanged(nameof(Student));
            OnPropertyChanged(nameof(Teacher));
        }

        public async Task LoadDataAsync(bool isReload = false)
        {
            using (BusyWorkRunner.CreateBusyWork(DoBusyWork))
            {
                Program program = await _mediator.Send(new Shared.Commands.Programs.GetProgram(Student.Program.Id));
                Appreciations = await _mediator.Send(new Shared.Commands.Common.GetAllCommand<Appreciation>(isReload));
                ProgramDays = program.ProgramDays.Select(x => new ProgramDayItemViewModel(x));
            }
        }

        [RelayCommand]
        private void SetMemorizingAppreciation(ProgramDayItemViewModel programDayItemViewModel)
        {

        }

        public Student Student { get; }
        public Teacher Teacher { get; }

        [ObservableProperty]
        private IEnumerable<ProgramDayItemViewModel> _programDays;

        [ObservableProperty]
        private IEnumerable<Appreciation> _appreciations;

        public DoBusyWork DoBusyWork { get; } = new DoBusyWork();
    }
}
