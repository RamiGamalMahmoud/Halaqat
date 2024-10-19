using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Halaqat.Features.MemorizingAndReview
{
    internal partial class ProgramDayItemViewModel : ObservableObject
    {
        public ProgramDayItemViewModel(ProgramDay programDay, IEnumerable<ProgramDayItemType> programDayItemTypes, IMessenger messenger)
        {
            ProgramDay = programDay;
            _programDayItemTypes ??= programDayItemTypes;
            _messenger = messenger;
            MemorizingAppreciations = new ObservableCollection<ProgramDayAppreciation>(
                programDay
                .ProgramDayAppreciations
                .Where(x => x.ProgramDayItemType.Name == "حفظ"));

            MemorizingAppreciation = MemorizingAppreciations
                .Select(x => x.Appreciation)
                .LastOrDefault();

            ReviewAppreciations = new ObservableCollection<ProgramDayAppreciation>(
                programDay
                .ProgramDayAppreciations
                .Where(x => x.ProgramDayItemType.Name == "مراجعة"));

            ReviewAppreciation = ReviewAppreciations
                .Select(x => x.Appreciation)
                .LastOrDefault();

            IsEnabled = CanSetMemorizingAppreciation || CanSetReviewAppreciation;
        }

        public ProgramDay ProgramDay { get; }

        [ObservableProperty]
        private Appreciation _memorizingAppreciation;

        [ObservableProperty]
        private bool _isEnabled;

        public bool HasMemorizingItems => ProgramDay.MemorizingItems is not null && ProgramDay.MemorizingItems.Any();
        public bool CanSetMemorizingAppreciation => CanSetAppreciation(HasMemorizingItems, MemorizingAppreciation);

        [ObservableProperty]
        private ObservableCollection<ProgramDayAppreciation> _memorizingAppreciations;

        [ObservableProperty]
        private Appreciation _reviewAppreciation;

        public bool HasReviewItems => ProgramDay.ReviewItems is not null && ProgramDay.ReviewItems.Any();
        public bool CanSetReviewAppreciation => CanSetAppreciation(HasReviewItems, ReviewAppreciation);

        [ObservableProperty]
        private ObservableCollection<ProgramDayAppreciation> _reviewAppreciations;

        private static bool CanSetAppreciation(bool hasItems, Appreciation appreciation)
        {
            if (appreciation is null) return hasItems;
            return hasItems && appreciation.Name == "إعادة";
        }

        [RelayCommand]
        private void SetMemorizingAppreciation()
        {
            MemorizingAppreciations.Add(new ProgramDayAppreciation()
            {
                Appreciation = MemorizingAppreciation,
                ProgramDayItemType = _programDayItemTypes.Where(x => x.Name == "حفظ").First(),
                DateAppreciated = DateTime.Now

            });
            OnPropertyChanged(nameof(CanSetMemorizingAppreciation));
            OnPropertyChanged(nameof(IsEnabled));
            _messenger.Send(new DayItemAppreciatedMessage(this));
        }

        [RelayCommand]
        private void SetReviewAppreciation()
        {
            ReviewAppreciations.Add(new ProgramDayAppreciation()
            {
                Appreciation = ReviewAppreciation,
                ProgramDayItemType = _programDayItemTypes.Where(x => x.Name == "مراجعة").First(),
                DateAppreciated = DateTime.Now

            });
            OnPropertyChanged(nameof(CanSetReviewAppreciation));
            OnPropertyChanged(nameof(IsEnabled));
            _messenger.Send(new DayItemAppreciatedMessage(this));
        }
        private static IEnumerable<ProgramDayItemType> _programDayItemTypes;
        private readonly IMessenger _messenger;
    }
}
