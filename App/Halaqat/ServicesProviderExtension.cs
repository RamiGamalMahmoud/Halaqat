using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Data;
using Halaqat.Helpers;
using Halaqat.Shared;
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
                ISettingsVewModel settings = s.GetRequiredService<ISettingsVewModel>();

                if(settings.IsLocalDatabase)
                {
                    return new AppDbContextFactory(@"
                        Server=.\SQLEXPRESS;
                        Integrated Security=SSPI;
                        Initial Catalog=halaqat;
                        TrustServerCertificate=True;
                        Trusted_Connection=True;");
                }

                return new AppDbContextFactory(@$"
                    Data Source={settings.IP},{settings.Port};
                    User Id={settings.UserId};
                    Password={settings.Password};
                    Initial Catalog=halaqat;
                    TrustServerCertificate=True;");
            });

            services.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);
            services.AddTransient<Shared.Abstraction.MainWindow.IMainWindowView, Halaqat.MainWindow.View>();
            services.AddTransient<MainWindow.ViewModel>();
            services.AddSingleton<AppHelper>();
            return services;
        }
    }
}
