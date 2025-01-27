﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared;
using Halaqat.Shared.Common;
using MediatR;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Halaqat.Features.Settings
{
    internal partial class ViewModel : ObservableObject, ISettingsVewModel
    {
        public ViewModel(Properties.Settings settings, IMediator mediator, IMessenger messenger)
        {
            _settings = settings;
            _mediator = mediator;
            _messenger = messenger;
            HasChangesObject = new HasChangesObject(() => SaveCommand.NotifyCanExecuteChanged());
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(CurrentView))
                HasChangesObject.SetHaschanges();

            if(_settings.AutoSave)
            {
                SaveCommand.Execute(null);
            }

            base.OnPropertyChanged(e);
        }

        public HasChangesObject HasChangesObject { get; }

        [ObservableProperty]
        private object _currentView;

        [RelayCommand]
        private async Task TestConnection()
        {
            bool canConnect = await _messenger.Send(new Messages.App.TestConnectionRequestMessageAsync());
            if (canConnect)
            {
                _messenger.Send(new Shared.Messages.Notifications.SuccessNotification("تم الاتصال"));
            }
            else
            {
                _messenger.Send(new Shared.Messages.Notifications.FailureNotification("فشل في الاتصال"));
            }
        }

        [RelayCommand]
        private async Task BackupDatabase()
        {
            await _mediator.Send(new Shared.Commands.Database.BackupCommand());
        }

        [RelayCommand]
        private async Task RestoreDatabase()
        {
            Result result = await _mediator.Send(new Shared.Commands.Database.RestoreCommand());
        }

        [RelayCommand(CanExecute = nameof(CanSave))]
        private void Save()
        {
            _settings.Save();
            HasChangesObject.SetNotHasChanges();
        }
        private bool CanSave() => HasChangesObject.HasChanges;

        private readonly Properties.Settings _settings;
        private readonly IMediator _mediator;
        private readonly IMessenger _messenger;
    }
}
