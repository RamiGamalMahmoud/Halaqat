using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Common;
using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Halaqat.Features.Circles.Editor
{
    internal abstract partial class ViewModel : ViewModelBase<CircleDataModel>
    {
        protected ViewModel(IMediator mediator, IMessenger messenger, Circle model) : base(mediator, messenger)
        {
            DataModel = new CircleDataModel(model);
            HasChangesObject = new HasChangesObject(SaveCommand.NotifyCanExecuteChanged);
            DataModel.PropertyChanged += DataModel_PropertyChanged;
        }

        public override bool CanSave() => HasChangesObject.HasChanges && DataModel.IsValid;

        public override async Task LoadDataAsync()
        {
            Teachers = await _mediator.Send(new Shared.Commands.Common.GetAllCommand<Teacher>(false));
            Students = (await _mediator.Send(new Shared.Commands.Students.GetStudentsWithNoCircleCommand()))
                .Select(x => new SelectableObject<Student>(x, false, StudentsChanged))
                .ToList();
        }

        public void StudentsChanged()
        {
            OnPropertyChanged(nameof(AllStudentsCount));
            OnPropertyChanged(nameof(StudentsWithNoCircleCount));
            OnPropertyChanged(nameof(SelectedStudents));
            HasChangesObject.SetHaschanges();
        }

        [RelayCommand]
        private void SelectAll()
        {
            foreach(SelectableObject<Student> student in Students)
            {
                student.IsSelected = true;
            }
        }

        [RelayCommand]
        private void DeSelectAll()
        {
            foreach (SelectableObject<Student> student in Students)
            {
                student.IsSelected = false;
            }
        }

        [ObservableProperty]
        private IEnumerable<Employee> _teachers;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(AllStudentsCount))]
        [NotifyPropertyChangedFor(nameof(StudentsWithNoCircleCount))]
        [NotifyPropertyChangedFor(nameof(SelectedStudents))]
        private IEnumerable<SelectableObject<Student>> _students;

        public int AllStudentsCount => Students is null ? 0 : Students.Count();
        public int StudentsWithNoCircleCount => Students is null ? 0 : Students.Where(x => !x.IsSelected).Count();
        public int SelectedStudents => Students is null ? 0 : Students.Where(x => x.IsSelected).Count();

    }

}
