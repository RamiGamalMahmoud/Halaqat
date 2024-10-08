using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Halaqat.Features.Programs.Editor
{
    public partial class ItemsView : UserControl
    {
        public ItemsView()
        {
            InitializeComponent();
        }

        public IEnumerable ItemsSource
        {
            get => (IEnumerable) GetValue(_itemsSourceProperty);
            set => SetValue(_itemsSourceProperty, value);
        }

        private static DependencyProperty _itemsSourceProperty = 
            DependencyProperty.Register(nameof(ItemsSource), typeof(IEnumerable), typeof(ItemsView), new PropertyMetadata(null));

        public ICommand RemoveItemCommand
        {
            get => GetValue(_removeItemCommandPrperty) as ICommand;
            set => SetValue(_removeItemCommandPrperty, value);
        }
        private static DependencyProperty _removeItemCommandPrperty =
            DependencyProperty.Register(nameof(RemoveItemCommand), typeof(ICommand), typeof(ItemsView), new PropertyMetadata(null));
    }
}
