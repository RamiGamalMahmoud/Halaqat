using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Halaqat.Shared.Models;
using System.Collections.Generic;
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

            SetAppreciations(programDay);

            _messenger.Register<ProgramDayViewModel, ValueChangedMessage<ProgramDayItemViewModel>>(this, OnProgramDayItemViewModelCanged);

            SetIsEnabled();
        }

        private void OnProgramDayItemViewModelCanged(ProgramDayViewModel r, ValueChangedMessage<ProgramDayItemViewModel> m)
        {
            OnPropertyChanged(nameof(IsEnabled));
            _messenger.Send(new ValueChangedMessage<ProgramDayViewModel>(this));
        }

        private void SetAppreciations(ProgramDay programDay)
        {
            bool hasMemorizingItems = programDay.MemorizingItems is not null && programDay.MemorizingItems.Any();
            bool hasReviewItems = programDay.ReviewItems is not null && programDay.ReviewItems.Any();

            IEnumerable<ProgramDayAppreciation> memorizingAppreciations = programDay
                .ProgramDayAppreciations
                .Where(x => x.ProgramDayItemType.Name == "حفظ").ToList();

            IEnumerable<ProgramDayAppreciation> reviewAppreciations = programDay
                .ProgramDayAppreciations
                .Where(x => x.ProgramDayItemType.Name == "مراجعة").ToList();

            ProgramDayItemType memorizingType = _programDayItemTypes.Where(x => x.Name == "حفظ").FirstOrDefault();
            ProgramDayItemType reviewType = _programDayItemTypes.Where(x => x.Name == "مراجعة").FirstOrDefault();

            ProgramDayMemorizingItemViewModel = new ProgramDayItemViewModel(ProgramDay, memorizingAppreciations, memorizingType, hasMemorizingItems, _messenger);
            ProgramDayReviewItemViewModel = new ProgramDayItemViewModel(ProgramDay, reviewAppreciations, reviewType, hasReviewItems, _messenger);

        }

        private void SetIsEnabled()
        {
            IsEnabled = ProgramDayMemorizingItemViewModel.CanInsertAppreciation || ProgramDayReviewItemViewModel.CanInsertAppreciation;
        }

        public bool HasMemorizingItems => ProgramDay.MemorizingItems is not null && ProgramDay.MemorizingItems.Any();
        public bool HasReviewItems => ProgramDay.ReviewItems is not null && ProgramDay.ReviewItems.Any();

        public ProgramDayItemViewModel ProgramDayMemorizingItemViewModel { get; private set; }
        public ProgramDayItemViewModel ProgramDayReviewItemViewModel { get; private set; }

        public ProgramDay ProgramDay { get; }
        public Student Student { get; }
        public Teacher Teacher { get; }

        [ObservableProperty]
        private bool _isEnabled;

        private static IEnumerable<ProgramDayItemType> _programDayItemTypes;
        private readonly IMessenger _messenger;
    }
}
