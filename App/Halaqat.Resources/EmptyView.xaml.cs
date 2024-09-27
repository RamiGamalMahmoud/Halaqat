using System.Windows.Controls;

namespace Halaqat.Resources
{
    public partial class EmptyView : UserControl
    {
        public EmptyView()
        {
            InitializeComponent();
            DataContext = this;
        }

        public string Text { get; set; }
    }
}
