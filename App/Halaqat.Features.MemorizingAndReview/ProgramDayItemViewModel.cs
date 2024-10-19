using CommunityToolkit.Mvvm.ComponentModel;
using Halaqat.Shared.Models;
using System.Linq;

namespace Halaqat.Features.MemorizingAndReview
{
    internal partial class ProgramDayItemViewModel : ObservableObject
    {
        public ProgramDayItemViewModel(ProgramDay programDay)
        {
            ProgramDay = programDay;
        }

        public ProgramDay ProgramDay { get; }

        public bool IsDayAppreciationCompleted => IsMemorizingAppreciationCompleted && IsReviewAppreciationCompleted;

        [ObservableProperty]
        private Appreciation _memorizingAppreciation;

        public bool HasMemorizingItems => ProgramDay.MemorizingItems is not null && ProgramDay.MemorizingItems.Any();
        public bool CanSetMemorizingAppreciation => CanSetAppreciation(HasMemorizingItems, MemorizingAppreciation);
        public bool IsMemorizingAppreciationCompleted => ProgramDay.MemorizingItems is not null && ProgramDay.MemorizingItems.Any() &&  MemorizingAppreciation is not null && MemorizingAppreciation.Name != "إعادة";

        [ObservableProperty]
        private Appreciation _reviewAppreciation;
        public bool IsReviewAppreciationCompleted => true;

        private bool CanSetAppreciation(bool hasItems, Appreciation appreciation)
        {
            if (appreciation is null) return hasItems;
            return hasItems && appreciation.Name == "إعادة";
        }
    }
}
