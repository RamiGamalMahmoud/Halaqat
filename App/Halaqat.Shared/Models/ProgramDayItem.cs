using CommunityToolkit.Mvvm.ComponentModel;

namespace Halaqat.Shared.Models
{
    [ObservableObject]
    public partial class ProgramDayItem : ModelBase
    {
        [ObservableProperty]
        private ProgramDay _programDay;

        [ObservableProperty]
        private ProgramDayItemType _programDayItemType;

        [ObservableProperty]
        private Sorah _sorah;

        [ObservableProperty]
        private Verse _verseFrom;

        [ObservableProperty]
        private Verse _verseTo;
    }
}
