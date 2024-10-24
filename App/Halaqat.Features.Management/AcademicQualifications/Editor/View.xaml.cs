using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Models;
using System.Windows;

namespace Halaqat.Features.Management.AcademicQualifications.Editor
{
    internal partial class View : Window
    {
        public View(ViewModel viewModel, IMessenger messenger)
        {
            InitializeComponent();
            DataContext = viewModel;

            messenger.Register<Shared.Messages.Common.EntityCreatedMessage<AcademicQualification>>(this, (r, m) => Close());
            messenger.Register<Shared.Messages.Common.EntityUpdatedMessage<AcademicQualification>>(this, (r, m) => Close());
        }
    }
}
