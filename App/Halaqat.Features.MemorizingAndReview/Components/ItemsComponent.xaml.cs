using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace Halaqat.Features.MemorizingAndReview.Components
{
    public partial class ItemsComponent : UserControl
    {
        public ItemsComponent()
        {
            InitializeComponent();
        }

        public IEnumerable ItemsSource
        {
            get => (IEnumerable)GetValue(_itemsSourceProperty);
            set => SetValue(_itemsSourceProperty, value);
        }

        private static DependencyProperty _itemsSourceProperty =
            DependencyProperty.Register(nameof(ItemsSource), typeof(IEnumerable), typeof(ItemsComponent), new PropertyMetadata(null));
    }
}
