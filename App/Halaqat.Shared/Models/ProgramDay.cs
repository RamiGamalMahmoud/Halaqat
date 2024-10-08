using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Halaqat.Shared.Models
{
    [ObservableObject]
    public partial class ProgramDay : ModelBase
    {
        public Program Program { get => _program; set => SetProperty(ref _program, value); }
        private Program _program;

        [ObservableProperty]
        private int _day;

        public Collection<ProgramDayItem> ProgramDayItems { get; } = [];

        public IEnumerable<ProgramDayItem> MemorizingItems => ProgramDayItems.Where(x => x.ProgramDayItemType.Name == "حفظ");
        public IEnumerable<ProgramDayItem> ReviewItems => ProgramDayItems.Where(x => x.ProgramDayItemType.Name == "مراجعة");
    }
}
