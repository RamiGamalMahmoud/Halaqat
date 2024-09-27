using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared;
using Microsoft.Extensions.Logging;
using Notification.Wpf;

namespace Halaqat.Helpers
{
    internal class AppHelper
    {
        public AppHelper(IMessenger messenger, ILogger<AppHelper> logger)
        {
            messenger.Register<Messages.Logging.LogErrorMessage>(this, (r, m) => logger.Log(LogLevel.Error, m.Message));

            messenger.Register<Messages.Notifications.SuccessNotification>(this, (r, m) => _notificationManager.Show("رسالة", m.Message, NotificationType.Success));
            messenger.Register<Messages.Notifications.FailureNotification>(this, (r, m) => _notificationManager.Show("رسالة", m.Message, NotificationType.Error));
            messenger.Register<Messages.Notifications.Notification>(this, (r, m) => _notificationManager.Show("رسالة", m.Message));
        }

        private readonly NotificationManager _notificationManager = new NotificationManager();
    }
}
