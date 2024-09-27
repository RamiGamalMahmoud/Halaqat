using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Data;
using Halaqat.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
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

            services.AddSingleton<Halaqat.Data.IAppDbContextFactory>(s =>
            {
                return new AppDbContextFactory(@"
Server=.\SQLEXPRESS2019;
Integrated Security=SSPI;
Initial Catalog=halaqat;
TrustServerCertificate=True;
Trusted_Connection=True;");
            });

            services.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);
            services.AddSingleton<Shared.Abstraction.MainWindow.IMainWindowView, Halaqat.MainWindow.View>();
            services.AddSingleton<MainWindow.ViewModel>();
            services.AddSingleton<AppHelper>();
            return services;
        }
    }
}
