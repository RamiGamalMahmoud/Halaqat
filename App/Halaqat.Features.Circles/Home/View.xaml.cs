﻿using System.Windows.Controls;
using Halaqat.Shared.Abstraction.Features.Circles;

namespace Halaqat.Features.Circles.Home
{
    internal partial class View : UserControl, IHomeView
    {
        public View(ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private async void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await Dispatcher.Invoke(() => (DataContext as ViewModel).LoadDataCommand.ExecuteAsync(false));
        }
    }
}
