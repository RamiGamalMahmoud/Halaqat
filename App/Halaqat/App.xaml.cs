using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Auth;
using Halaqat.Data;
using Halaqat.Features.Circles;
using Halaqat.Features.Employees;
using Halaqat.Features.Management;
using Halaqat.Features.MemorizingAndReview;
using Halaqat.Features.Print;
using Halaqat.Features.Programs;
using Halaqat.Features.Settings;
using Halaqat.Features.Students;
using Halaqat.Features.Users;
using Halaqat.Helpers;
using Halaqat.Shared;
using Halaqat.Shared.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Velopack;

namespace Halaqat
{
    public partial class App : Application
    {
        public App()
        {
            VelopackApp.Build().Run();

            CultureInfo cultureInfo = new CultureInfo("ar");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            _host = CreateHost();
            _messenger = _host.Services.GetRequiredService<IMessenger>();
            _appHelper = _host.Services.GetRequiredService<AppHelper>();

            ShutdownMode = ShutdownMode.OnMainWindowClose;
            DispatcherUnhandledException += App_DispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;


            _messenger.Register<Messages.Users.LoggedInUserRequestMessage>(this, (r, m) =>
            {
                m.Reply(_user);
            });

            _messenger.Register<Messages.Users.GetEmployeesPrivilegesRequestMessage>(this, (r, m) =>
            {
                m.Reply(_user.EmployeesManagementPrivileges);
            });

            _messenger.Register<Messages.Users.GetStudentsPrivilegesRequestMessage>(this, (r, m) =>
            {
                m.Reply(_user.StudentsManagementPrivileges);
            });

            _messenger.Register<Messages.Users.GetCirclesPrivilegesRequestMessage>(this, (r, m) =>
            {
                m.Reply(_user.CirclesManagementPrivileges);
            });

            _messenger.Register<Messages.Users.GetProgramsPrivilegesRequestMessage>(this, (r, m) =>
            {
                m.Reply(_user.ProgramsManagementPrivileges);
            });

            _messenger.Register<Messages.Users.GetUsersPrivilegesRequestMessage>(this, (r, m) =>
            {
                m.Reply(_user.UsersManagementPrivileges);
            });

            _messenger.Register<Messages.Users.LoginSucceded>(this, (r, m) =>
            {
                _user = m.User;
                ShowMaindWindow();
            });

            _messenger.Register<Messages.Users.LoginFailed>(this, (r, m) =>
            {
                _messenger.Send(new Messages.Logging.LogErrorMessage("Login Failed"));
                MessageBox.Show("اسم المستخدم غير موجود أو كلمة مرور خاطئة");
            });

            _messenger.Register<Messages.Users.LogoutMessage>(this, (r, m) =>
            {
                Restart();
            });

        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.ToString());
        }

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
#if DEBUG
            MessageBox.Show(e.Exception.Message);
#endif
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
            services.ConfigureAppService();
            services.ConfigureProgramsFeature();
            services.ConfigureCirclesFeature();
            services.ConfigureData();
            services.ConfigureUsersFeature();
            services.ConfigureAuthFeature();
            services.ConfigurePrintFeature();
            services.ConfigureEmployeesFeature();
            services.ConfigureStudentsFeature();
            services.ConfigureMemorizingAndReviewFeature();
            services.ConfigureSettingsFeature();
            services.ConfigureManagementFeature();
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
            MainWindow = new Window();
            _messenger.Send(new Messages.Notifications.Notification("جاري التحقق من الاتصال بقاعدة البيانات"));

            if (!(await _messenger.Send(new Messages.App.TestConnectionRequestMessageAsync())))
            {
                _messenger.Send(new Messages.Notifications.FailureNotification("لم يتم الاتصال بقاعدة البيانات"));

                if ((await _messenger.Send(new Messages.App.TestConnectionRequestMessageWitoutDatabaseAsync())))
                {
                    _messenger.Send(new Messages.Notifications.Notification("تم الاتصال بالخادم"));
                    _messenger.Send(new Messages.Notifications.Notification("يجب ضبط بيانات الاتصال و انشاء قاعدة البيانات"));
                }

                RunConfiguration();
            }

            else
            {
                _messenger.Send(new Messages.Notifications.SuccessNotification("تم الاتصال بقاعدة البيانات بنجاح"));
                await Start();
            }

            base.OnStartup(e);
            await _host.RunAsync();
        }

        private void RunConfiguration()
        {
            MainWindow = _host.Services.GetRequiredService<Shared.Abstraction.Features.Settings.IDatabaseConfigurationView>() as Window;
            MainWindow.Show();
        }

        private async Task Start()
        {
            await _appHelper.ApplyMigrations();
            MainWindow = _host.Services.GetRequiredService<Shared.Abstraction.Features.Auth.ILoginView>() as Window;
            MainWindow.Show();
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
        private User _user;
    }

}
