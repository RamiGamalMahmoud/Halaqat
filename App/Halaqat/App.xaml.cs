using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Auth;
using Halaqat.Features.Employees;
using Halaqat.Features.Users;
using Halaqat.Features.Students;
using Halaqat.Helpers;
using Halaqat.Shared;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;
using Velopack;
using Halaqat.Data;
using Halaqat.Features.Circles;

namespace Halaqat
{
    public partial class App : Application
    {
        public App()
        {
            VelopackApp.Build().Run(); 
            _host = CreateHost();
            ShutdownMode = ShutdownMode.OnMainWindowClose;
            DispatcherUnhandledException += App_DispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            _appHelper = _host.Services.GetRequiredService<AppHelper>();
            _messenger = _host.Services.GetRequiredService<IMessenger>();

            _messenger.Register<Messages.Users.LoginSucceded>(this, (r, m) =>
            {
                ShowMaindWindow();
            });

            _messenger.Register<Messages.Users.LoginFailed>(this, (r, m) =>
            {
                MessageBox.Show("login failed");
            });

        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.ToString());
        }

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
#if !DEBUG
            e.Handled = true;
#endif
        }

        private IHost CreateHost()
        {
            return Host
                .CreateDefaultBuilder()
                .ConfigureServices(services => ConfigureServices(services))
                .Build();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureCirclesFeature();
            services.ConfigureData();
            services.ConfigureUsersFeature();
            services.ConfigureAppService();
            services.ConfigureAuthFeature();
            services.ConfigureEmployeesFeature();
            services.ConfigureStudentsFeature();
        }

        private void ShowMaindWindow()
        {
            Window window = MainWindow;
            MainWindow = _host.Services.GetRequiredService<Shared.Abstraction.MainWindow.IMainWindowView>() as Window;
            MainWindow.Show();
            window.Close();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            MainWindow = _host.Services.GetRequiredService<Shared.Abstraction.Features.Auth.ILoginView>() as Window;
            MainWindow.Show();
            base.OnStartup(e);
            await _host.RunAsync();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }

        public void Restart()
        {
            Process.Start(Process.GetCurrentProcess().MainModule.FileName);
            Shutdown();
        }

        private readonly IHost _host;
        private readonly AppHelper _appHelper;
        private readonly IMessenger _messenger;
    }

}
