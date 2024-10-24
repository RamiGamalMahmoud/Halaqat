using CommunityToolkit.Mvvm.ComponentModel;
using Halaqat.Shared;
using System.ComponentModel;

namespace Halaqat.Features.Settings
{
    internal partial class ViewModel : ObservableObject, ISettingsVewModel
    {
        public ViewModel(Properties.Settings settings)
        {
            _settings = settings;
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            _settings.Save();
            base.OnPropertyChanged(e);
        }

        public bool IsLocalDatabase
        {
            get => _settings.IsLocalDatabase;
            set
            {
                _settings.IsLocalDatabase = value;
            }
        }

        public string Server
        {
            get => _settings.Server;
            set
            {
                _settings.Server = value;
                OnPropertyChanged(nameof(Server));
            }
        }

        public string IP
        {
            get => _settings.IP;
            set
            {
                _settings.IP = value;
                OnPropertyChanged(nameof(IP));
            }
        }

        public int Port
        {
            get => _settings.Port;
            set
            {
                _settings.Port = value;
            }
        }

        public string Password
        {
            get => _settings.Password;
            set
            {
                _settings.Password = value;
            }
        }

        public string UserId
        {
            get => _settings.UserId;
            set
            {
                _settings.UserId = value;
            }
        }

        private readonly Properties.Settings _settings;
    }
}
