using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Halaqat.Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Halaqat.Features.MemorizingAndReview
{
    public partial class ProgramDayItemViewModel : ObservableObject
    {
        public ProgramDayItemViewModel(ProgramDay programDay,
            IEnumerable<ProgramDayAppreciation> programDayAppreciations,
            ProgramDayItemType programDayItemType,
            bool hasItems,
            IMessenger messenger)
        {
            _programDay = programDay;
            _programDayItemType = programDayItemType;
            HasItems = hasItems;
            _messenger = messenger;
            ProgramDayAppreciations = new ObservableCollection<ProgramDayAppreciation>(programDayAppreciations);
        }

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(InsertApprecationCommand))]
        private Appreciation _appreciation;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasItems))]
        [NotifyPropertyChangedFor(nameof(CanInsertAppreciation))]
        private ObservableCollection<ProgramDayAppreciation> _programDayAppreciations;
        public IEnumerable<ProgramDayAppreciation> NewProgramDayAppreciations => _newProgramDayAppreciations;
        private List<ProgramDayAppreciation> _newProgramDayAppreciations = [];

        public void ClearNewItems()
        {
            _newProgramDayAppreciations.Clear();
        }

        partial void OnProgramDayAppreciationsChanged(ObservableCollection<ProgramDayAppreciation> oldValue, ObservableCollection<ProgramDayAppreciation> newValue)
        {
            if (newValue is null || newValue.Any())
            {
                Appreciation = ProgramDayAppreciations.LastOrDefault().Appreciation;
            }
        }

        private readonly ProgramDay _programDay;
        private readonly ProgramDayItemType _programDayItemType;
        private readonly IMessenger _messenger;

        public bool HasItems { get; }
        public bool CanInsertAppreciation
        {
            get
            {
                if (Appreciation is null) return HasItems;
                return HasItems && Appreciation.Name == "إعادة";
            }
        }

        [RelayCommand(CanExecute = nameof(HasValidAppreciation))]
        private void InsertApprecation()
        {
            ProgramDayAppreciation programDayAppreciation = new ProgramDayAppreciation()
            {
                ProgramDay = _programDay,
                Appreciation = Appreciation,
                ProgramDayItemType = _programDayItemType,
                DateAppreciated = DateTime.Now
            };

            ProgramDayAppreciations.Add(programDayAppreciation);
            _newProgramDayAppreciations.Add(programDayAppreciation);
            OnPropertyChanged(nameof(CanInsertAppreciation));
            _messenger.Send(new ValueChangedMessage<ProgramDayItemViewModel>(this));
        }

        private bool HasValidAppreciation() => Appreciation is not null;
    }
}
