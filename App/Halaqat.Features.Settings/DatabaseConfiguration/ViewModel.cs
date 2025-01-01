
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Data;
using Halaqat.Shared;
using Halaqat.Shared.Common;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Halaqat.Features.Settings.DatabaseConfiguration
{
    internal partial class ViewModel : ObservableObject
    {
        public ViewModel(Properties.Settings settings, IMessenger messenger, SqlConnectionFactory sqlConnectionFactory)
        {
            _settings = settings;
            _messenger = messenger;
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public bool IsLocalDatabase
        {
            get => _settings.IsLocalDatabase;
            set => SetProperty(_settings.IsLocalDatabase, value, _settings, (o, v) => o.IsLocalDatabase = v);
        }

        public string Server
        {
            get => _settings.Server;
            set => SetProperty(_settings.Server, value, _settings, (o, v) => o.Server = v);
        }

        public string IP
        {
            get => _settings.IP;
            set => SetProperty(_settings.IP, value, _settings, (o, v) => o.IP = v);
        }

        public int Port
        {
            get => _settings.Port;
            set => SetProperty(_settings.Port, value, _settings, (o, v) => o.Port = v);
        }

        public string Password
        {
            get => _settings.Password;
            set => SetProperty(_settings.Password, value, _settings, (o, v) => o.Password = v);
        }

        public string UserId
        {
            get => _settings.UserId;
            set => SetProperty(_settings.UserId, value, _settings, (o, v) => o.UserId = v);
        }

        [RelayCommand]
        private void Save()
        {
            _settings.Save();
            HasChangesObject.SetNotHasChanges();
        }

        [RelayCommand]
        private async Task TestConnection()
        {
            bool canConnect = await _messenger.Send(new Messages.App.TestConnectionRequestMessageAsync());
            if (canConnect)
            {
                _messenger.Send(new Shared.Messages.Notifications.SuccessNotification("تم الاتصال"));
            }
            else
            {
                _messenger.Send(new Shared.Messages.Notifications.FailureNotification("فشل في الاتصال"));
            }
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            HasChangesObject.SetHaschanges();
            base.OnPropertyChanged(e);
        }

        [RelayCommand]
        private async Task CreateDatabase()
        {
            using (SqlConnection connection = _sqlConnectionFactory.CreateSqlConnection())
            {
                try
                {
                    await connection.OpenAsync();
                }
                catch (System.Exception)
                {
                    _messenger.Send(new Shared.Messages.Notifications.FailureNotification("فشل في الاتصال"));
                    return;
                }

                SqlCommand cmd = new SqlCommand("CREATE DATABASE halaqat COLLATE Arabic_100_CI_AI", connection);

                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    _messenger.Send(new Shared.Messages.Notifications.SuccessNotification("تم إنشاء قاعدة البيانات"));
                }
                catch (System.Exception)
                {
                    _messenger.Send(new Shared.Messages.Notifications.FailureNotification("قاعدة البيانات موجودة بالفعل"));
                }
            }
        }

        public HasChangesObject HasChangesObject { get; } = new HasChangesObject();

        private readonly Properties.Settings _settings;
        private readonly IMessenger _messenger;
        private readonly SqlConnectionFactory _sqlConnectionFactory;
    }
}
