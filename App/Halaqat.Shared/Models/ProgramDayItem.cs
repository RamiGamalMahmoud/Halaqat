using CommunityToolkit.Mvvm.ComponentModel;

namespace Halaqat.Shared.Models
{
    [ObservableObject]
    public partial class ProgramDayItem : ModelBase
    {
        public int ProgramDayId { get; set; }
        [ObservableProperty]
        private ProgramDay _programDay;

        public int ProgramDayItemTypeId { get; set; }

        [ObservableProperty]
        private ProgramDayItemType _programDayItemType;

        public int? SorahId { get; set; }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasSorah))]
        private Sorah _sorah;

        public int? VerseFromId { get; set; }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasVerseFrom))]
        [NotifyPropertyChangedFor(nameof(HasVerses))]
        private Verse _verseFrom;

        public int? VerseToId { get; set; }
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasVerseTo))]
        [NotifyPropertyChangedFor(nameof(HasVerses))]
        private Verse _verseTo;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasNotes))]
        private string _notes;

        public bool HasSorah => Sorah is not null;
        public bool HasVerseFrom => VerseFrom is not null;
        public bool HasVerseTo => VerseTo is not null;
        public bool HasVerses => HasVerseFrom && HasVerseTo;
        public bool HasNotes => !string.IsNullOrEmpty(Notes);

        public override string ToString()
        {
            string verses = "";

            if(HasSorah && HasVerseFrom && HasVerseTo)
            {
                verses = VerseFrom.Number + " - " + VerseTo.Number;
            }

            string sorah = HasSorah ? Sorah.Name : "";

            return $"{Notes} {sorah} {verses}";
        }
    }
}
