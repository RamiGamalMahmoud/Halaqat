namespace Halaqat.Shared
{
    public interface ISettingsVewModel : IDatabaseSettings
    {

    }

    public interface IDatabaseSettings
    {
        public string Server { get; }
        public bool IsLocalDatabase { get; }
        public string UserId { get; }
        public string Password { get; }
        public string IP { get; }
        public string Port { get; }
        public bool AutoSave { get; }
    }

    public interface IGeneralSettings
    {
        public bool AutoSave { get; }
    }
}
