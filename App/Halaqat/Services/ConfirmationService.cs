using System.Windows;

namespace Halaqat.Services
{
    internal class ConfirmationService
    {
        public bool Confirm(string message)
        {
            MessageBoxResult result = MessageBox.Show(message, "رسالة تأكيد", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            return result == MessageBoxResult.Yes;
        }
    }
}
