using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Halaqat.Features.Programs.Editor
{
    [ObservableObject]
    public partial class AddMemoOrReview : Window
    {
        public AddMemoOrReview(IMediator mediator, IMessenger messenger)
        {
            InitializeComponent();
            _mediator = mediator;
            _messenger = messenger;
            DataContext = this;
            Items.CollectionChanged += Items_CollectionChanged;
        }

        private void Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            SaveCommand.NotifyCanExecuteChanged();
        }

        [ObservableProperty]
        private IEnumerable<Sorah> _sorahs;

        public IEnumerable<Verse> Verses { get => _verses; private set => SetProperty(ref _verses, value); }
        IEnumerable<Verse> _verses;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddCommand))]
        private Sorah _sorah;

        [ObservableProperty]
        private Verse _verseFrom;

        [ObservableProperty]
        private Verse _verseTo;

        public ObservableCollection<Item> Items { get; set; } = [];

        [ObservableProperty]
        private IEnumerable<ProgramDayItemType> _programDayItemTypes;

        private readonly IMediator _mediator;
        private readonly IMessenger _messenger;

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Sorahs = await _mediator.Send(new Shared.Commands.Common.GetAllCommand<Sorah>(false));
            ProgramDayItemTypes = await _mediator.Send(new Shared.Commands.Common.GetAllCommand<ProgramDayItemType>(false));
        }

        async partial void OnSorahChanged(Sorah oldValue, Sorah newValue)
        {
            if (newValue is not null)
            {
                Verses = await _mediator.Send(new CommandHandlers.GetSorahVersesCommand.Command(newValue.Id));
            }
        }

        public bool CanAddItem()
        {
            return Sorah is not null;
        }

        [RelayCommand(CanExecute = nameof(CanAddItem))]
        private void Add()
        {
            Items.Add(new Item(Sorah, VerseFrom, VerseTo));
            Sorah = null;
            VerseFrom = null;
            VerseTo = null;
        }

        private bool CanSave()
        {
            return Items.Any();
        }

        [RelayCommand(CanExecute = nameof(CanSave))]
        private void Save()
        {
            DialogResult = true;
        }

        [RelayCommand]
        private void RemoveItem(Item item)
        {
            Items.Remove(item);
        }

        [RelayCommand]
        private void Exit()
        {
            DialogResult = false;
        }
    }

    public record Item(Sorah Sorah, Verse VerseFrom, Verse VerseTo);
}
