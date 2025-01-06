namespace Halaqat.Features.Settings
{
    internal partial class ViewModel
    {
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

        public string Port
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
    }
}
