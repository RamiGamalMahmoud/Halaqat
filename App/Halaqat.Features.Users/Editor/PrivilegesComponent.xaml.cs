using Halaqat.Shared.Models;
using System.Windows;
using System.Windows.Controls;

namespace Halaqat.Features.Users.Editor
{
    public partial class PrivilegesComponent : UserControl
    {
        public PrivilegesComponent()
        {
            InitializeComponent();
        }

        public string Title
        {
            get => GetValue(_titleProperty) as string;
            set => SetValue(_titleProperty, value);
        }
        private static DependencyProperty _titleProperty = 
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(PrivilegesComponent), new PropertyMetadata(""));

        public Privileges Privileges
        {
            get => GetValue(_privilegesProperty) as Privileges;
            set => SetValue(_privilegesProperty, value);
        }
        private static DependencyProperty _privilegesProperty =
            DependencyProperty.Register(nameof(Privileges), typeof(Privileges), typeof(PrivilegesComponent), new PropertyMetadata(null));
    }
}
