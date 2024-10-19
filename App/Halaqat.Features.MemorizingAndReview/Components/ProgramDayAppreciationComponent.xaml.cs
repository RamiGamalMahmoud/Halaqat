using Halaqat.Shared.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Halaqat.Features.MemorizingAndReview.Components
{
    public partial class ProgramDayAppreciationComponent : UserControl
    {
        public ProgramDayAppreciationComponent()
        {
            InitializeComponent();
        }

        public bool CanSetAppreciation
        {
            get => (bool) GetValue(_canSetAppreciation);
            set => SetValue(_canSetAppreciation, value);
        }
        private static DependencyProperty _canSetAppreciation = 
            DependencyProperty.Register(nameof(CanSetAppreciation), typeof(bool), typeof(ProgramDayAppreciationComponent), new PropertyMetadata(false));

        public bool HasItems
        {
            get => (bool) GetValue(_hasItems);
            set => SetValue(_hasItems, value);
        }
        private static DependencyProperty _hasItems =
            DependencyProperty.Register(nameof(HasItems), typeof(bool), typeof(ProgramDayAppreciationComponent), new PropertyMetadata(false));

        public Appreciation Appreciation
        {
            get => (Appreciation) GetValue(_appreciation);
            set => SetValue(_appreciation, value);
        }
        private static DependencyProperty _appreciation =
            DependencyProperty.Register(nameof(Appreciation), typeof(Appreciation), typeof(ProgramDayAppreciationComponent), new PropertyMetadata(null));

        public IEnumerable<Appreciation> Appreciations
        {
            get => (IEnumerable<Appreciation>) GetValue(_appreciations);
            set => SetValue(_appreciations, value);
        }
        private static DependencyProperty _appreciations =
            DependencyProperty.Register(nameof(Appreciations), typeof(IEnumerable<Appreciation>), typeof(ProgramDayAppreciationComponent), new PropertyMetadata(null));
    
        public ICommand Command
        {
            get => (ICommand) GetValue(_commandProperty);
            set => SetValue(_commandProperty, value);
        }
        private static DependencyProperty _commandProperty =
            DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(ProgramDayAppreciationComponent), new PropertyMetadata(null));

        public object CommandParameter
        {
            get => GetValue(_commandParameter);
            set => SetValue(_commandParameter, value);
        }
        private static DependencyProperty _commandParameter =
            DependencyProperty.Register(nameof(CommandParameter), typeof(object), typeof(ProgramDayAppreciationComponent), new PropertyMetadata(null));
    }
}
