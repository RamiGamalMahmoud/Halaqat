using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Common;
using Halaqat.Shared.Models;
using MediatR;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Halaqat.Features.Programs.Editor
{
    internal abstract partial class ViewModel : ViewModelBase<ProgramDataModel>
    {
        public ViewModel(IMediator mediator, IMessenger messenger, Program model) : base(mediator, messenger)
        {
            DataModel = new ProgramDataModel(model);
            HasChangesObject = new HasChangesObject(SaveCommand.NotifyCanExecuteChanged);
            DataModel.PropertyChanged += DataModel_PropertyChanged;
        }
        public override bool CanSave() => HasChangesObject.HasChanges && DataModel.IsValid;


        public override Task LoadDataAsync()
        {
            return Task.CompletedTask;
        }

        [RelayCommand(CanExecute = nameof(CanInsertProgramDay))]
        private void InsertProgramDay()
        {
            ProgramDay programDay = new ProgramDay
            {
                Day = (int)Day
            };

            foreach (ProgramDayItem programDayItem in MemorizingProgramDayItems)
            {
                programDay.ProgramDayItems.Add(programDayItem);
            }

            foreach (ProgramDayItem programDayItem in ReviewProgramDayItems)
            {
                programDay.ProgramDayItems.Add(programDayItem);
            }

            DataModel.ProgramDays.Add(programDay);


            Day = null;
            MemorizingProgramDayItems.Clear();
            ReviewProgramDayItems.Clear();
        }

        [RelayCommand]
        private void InsertMemorizing()
        {
            AddMemoOrReview addMemoOrReview = new AddMemoOrReview(_mediator, _messenger);
            if (addMemoOrReview.ShowDialog() == true)
            {
                foreach(Item item in addMemoOrReview.Items)
                {
                    ProgramDayItem programDayItem = new ProgramDayItem()
                    {
                        Sorah = item.Sorah,
                        VerseFrom = item.VerseFrom,
                        VerseTo = item.VerseTo,
                        ProgramDayItemType = addMemoOrReview.ProgramDayItemTypes.Where(x => x.Name == "حفظ").FirstOrDefault()
                    };
                    MemorizingProgramDayItems.Add(programDayItem);
                }
            }
        }

        [RelayCommand]
        private void InsertReview()
        {
            AddMemoOrReview addMemoOrReview = new AddMemoOrReview(_mediator, _messenger);
            if (addMemoOrReview.ShowDialog() == true)
            {
                foreach (Item item in addMemoOrReview.Items)
                {
                    ProgramDayItem programDayItem = new ProgramDayItem()
                    {
                        Sorah = item.Sorah,
                        VerseFrom = item.VerseFrom,
                        VerseTo = item.VerseTo,
                        ProgramDayItemType = addMemoOrReview.ProgramDayItemTypes.Where(x => x.Name == "مراجعة").FirstOrDefault()
                    };
                    ReviewProgramDayItems.Add(programDayItem);
                }
            }
        }

        [RelayCommand]
        private void RemoveMemorizingItem(ProgramDayItem item)
        {
            MemorizingProgramDayItems.Remove(item);
        }

        [RelayCommand]
        private void RemoveReviewItem(ProgramDayItem item)
        {
            ReviewProgramDayItems.Remove(item);
        }

        protected bool CanInsertProgramDay() => Day is not null;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(InsertProgramDayCommand))]
        private int? _day;

        public ObservableCollection<ProgramDayItem> MemorizingProgramDayItems { get; } = [];
        public ObservableCollection<ProgramDayItem> ReviewProgramDayItems { get; } = [];
    }
}
