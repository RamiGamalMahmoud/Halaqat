﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Common;
using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Halaqat.Features.Students.Editor
{
    internal abstract partial class ViewModel : ViewModelBase<StudentDataModel>
    {
        protected ViewModel(IMediator mediator, IMessenger messenger, Student student) : base(mediator, messenger)
        {
            DataModel = new StudentDataModel(student);
            HasChangesObject = new HasChangesObject(SaveCommand.NotifyCanExecuteChanged);
            DataModel.PropertyChanged += DataModel_PropertyChanged;
        }

        public override async Task LoadDataAsync()
        {
            Cities = await _mediator.Send(new Shared.Commands.Common.GetAllCommand<City>(false));
            Genders = await _mediator.Send(new Shared.Commands.Common.GetAllCommand<Gender>(false));
            Circles = await _mediator.Send(new Shared.Commands.Common.GetAllCommand<Circle>(false));
            Programs = await _mediator.Send(new Shared.Commands.Common.GetAllCommand<Program>(false));
            EducationalStages = await _mediator.Send(new Shared.Commands.Common.GetAllCommand<EducationalStage>(false));
        }

        protected override async void DataModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(DataModel.EducationalStage) && DataModel.EducationalStage is not null)
            {
                Classes = await _mediator.Send(new CommandHandlers.GetEducationalStageClasses.Command(DataModel.EducationalStage.Id));
            }
            base.DataModel_PropertyChanged(sender, e);
        }

        public bool CanChangeProgram => DataModel.Program is null;

        [RelayCommand(CanExecute = nameof(CanInsertPhone))]
        private void InsertPhone()
        {
            DataModel.Phones.Add(new Phone() { Number = PhoneNumber });
            PhoneNumber = "";
        }

        [RelayCommand]
        private void RemovePhone(Phone phone) => DataModel.Phones.Remove(phone);

        private bool CanInsertPhone() => !string.IsNullOrWhiteSpace(PhoneNumber);

        [ObservableProperty]
        private string _phoneNumber;

        [ObservableProperty]
        private IEnumerable<City> _cities;

        [ObservableProperty]
        private IEnumerable<Gender> _genders;

        [ObservableProperty]
        private IEnumerable<Circle> _circles;

        [ObservableProperty]
        private IEnumerable<EducationalStage> _educationalStages;

        [ObservableProperty]
        private IEnumerable<Class> _classes;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(CanChangeProgram))]
        private IEnumerable<Program> _programs;

        public override bool CanSave() => HasChangesObject.HasChanges && DataModel.IsValid;
    }
}
