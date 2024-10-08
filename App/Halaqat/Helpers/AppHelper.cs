using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Data;
using Halaqat.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Notification.Wpf;
using System.Linq;
using System.Threading.Tasks;

namespace Halaqat.Helpers
{
    internal class AppHelper
    {
        public AppHelper(IMessenger messenger, ILogger logger, IAppDbContextFactory dbContextFactory)
        {
            messenger.Register<Messages.Logging.LogErrorMessage>(this, (r, m) => logger.Log(LogLevel.Error, m.Message));

            messenger.Register<Messages.Notifications.SuccessNotification>(this, (r, m) => _notificationManager.Show("رسالة", m.Message, NotificationType.Success));
            messenger.Register<Messages.Notifications.FailureNotification>(this, (r, m) => _notificationManager.Show("رسالة", m.Message, NotificationType.Error));
            messenger.Register<Messages.Notifications.Notification>(this, (r, m) => _notificationManager.Show("رسالة", m.Message));
            _dbContextFactory = dbContextFactory;
        }

        public async Task ApplyMigrations()
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();
                if (pendingMigrations.Any())
                {
                    await dbContext.Database.MigrateAsync();
                }
            }
        }

        private readonly NotificationManager _notificationManager = new NotificationManager();
        private readonly IAppDbContextFactory _dbContextFactory;
    }
}
