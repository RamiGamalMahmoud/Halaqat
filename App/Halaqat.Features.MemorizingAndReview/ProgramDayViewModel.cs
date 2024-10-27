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
    internal partial class ProgramDayViewModel : ObservableObject
    {
        public ProgramDayViewModel(ProgramDay programDay,
            Student student,
            Teacher teacher,
            IEnumerable<ProgramDayItemType> programDayItemTypes,
            IMessenger messenger)
        {
            ProgramDay = programDay;
            Student = student;
            Teacher = teacher;
            _programDayItemTypes ??= programDayItemTypes;
            _messenger = messenger;

            _messenger.Register<ValueChangedMessage<ProgramDayItemViewModel>>(this, (r, m) =>
            {
                OnPropertyChanged(nameof(IsEnabled));
                _messenger.Send(new DayItemAppreciatedMessage(this));
            });

            IEnumerable<ProgramDayAppreciation> memorizingAppreciations = programDay
                .ProgramDayAppreciations
                .Where(x => x.ProgramDayItemType.Name == "حفظ").ToList();

            IEnumerable<ProgramDayAppreciation> reviewAppreciations = programDay
                .ProgramDayAppreciations
                .Where(x => x.ProgramDayItemType.Name == "مراجعة").ToList();

            bool hasMemorizingItems = programDay.MemorizingItems is not null && programDay.MemorizingItems.Any();
            bool hasReviewItems = programDay.ReviewItems is not null && programDay.ReviewItems.Any();


            ProgramDayItemType memorizingType = programDayItemTypes.Where(x => x.Name == "حفظ").FirstOrDefault();
            ProgramDayItemType reviewType = programDayItemTypes.Where(x => x.Name == "مراجعة").FirstOrDefault();

            ProgramDayMemorizingItemViewModel = new ProgramDayItemViewModel(ProgramDay, memorizingAppreciations, memorizingType, hasMemorizingItems, messenger);
            ProgramDayReviewItemViewModel = new ProgramDayItemViewModel(ProgramDay, reviewAppreciations, reviewType, hasReviewItems, messenger);

            IsEnabled = ProgramDayMemorizingItemViewModel.CanInsertAppreciation || ProgramDayReviewItemViewModel.CanInsertAppreciation;
        }

        public bool HasMemorizingItems => ProgramDay.MemorizingItems is not null && ProgramDay.MemorizingItems.Any();
        public bool HasReviewItems => ProgramDay.ReviewItems is not null && ProgramDay.ReviewItems.Any();

        public ProgramDayItemViewModel ProgramDayMemorizingItemViewModel { get; }
        public ProgramDayItemViewModel ProgramDayReviewItemViewModel { get; }

        public ProgramDay ProgramDay { get; }
        public Student Student { get; }
        public Teacher Teacher { get; }

        [ObservableProperty]
        private bool _isEnabled;

        private static IEnumerable<ProgramDayItemType> _programDayItemTypes;
        private readonly IMessenger _messenger;
    }

    partial class ProgramDayItemViewModel : ObservableObject
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
            ProgramDayAppreciations.Add(new ProgramDayAppreciation()
            {
                ProgramDay = _programDay,
                Appreciation = Appreciation,
                ProgramDayItemType = _programDayItemType,
                DateAppreciated = DateTime.Now
            });
            OnPropertyChanged(nameof(CanInsertAppreciation));
            _messenger.Send(new ValueChangedMessage<ProgramDayItemViewModel>(this));
        }

        private bool HasValidAppreciation() => Appreciation is not null;
    }
}
