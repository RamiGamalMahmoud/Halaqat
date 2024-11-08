using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Data;
using Halaqat.Helpers;
using Halaqat.Shared;
using Halaqat.Shared.Common;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Data.Common;
using System.IO;

namespace Halaqat
{
    internal static class ServicesProviderExtension
    {
        public static IServiceCollection ConfigureAppService(this IServiceCollection services)
        {
            ILoggerFactory logger = LoggerFactory.Create(builder =>
            {
                string logsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "halaqat");
                Directory.CreateDirectory(logsFolder);
                string logs = Path.Combine(logsFolder, DateTime.Now.ToString("yyyy-MM-dd"));

                LoggerConfiguration loggerConfiguration = new LoggerConfiguration()
                    .WriteTo.File($"{logs}.txt")
#if DEBUG
                    .WriteTo.Debug()
#endif
                    .MinimumLevel.Information();

                builder.AddSerilog(loggerConfiguration.CreateLogger());
            });

            services.AddSingleton<Microsoft.Extensions.Logging.ILogger>(x =>
            {
                return logger.CreateLogger("logging");
            });

            services.AddSingleton<AppHelper>();
            services.AddTransient<ConnectionStringFactory>();
            services.AddSingleton<SqlConnectionFactory>();
            services.AddSingleton<Halaqat.Data.IAppDbContextFactory, AppDbContextFactory>();

            services.AddSingleton<MainWindow.AdministrativeOfficers.ViewModel>();
            services.AddSingleton<MainWindow.AdministrativeOfficers.View>();

            services.AddSingleton<MainWindow.Teachers.ViewModel>();
            services.AddSingleton<MainWindow.Teachers.View>();

            services.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);
            services.AddSingleton<Shared.Abstraction.MainWindow.IMainWindowView, Halaqat.MainWindow.View>();
            services.AddSingleton<MainWindow.ViewModel>();
            return services;
        }
    }
}
