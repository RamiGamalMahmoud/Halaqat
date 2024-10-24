namespace Halaqat.Shared
{
    public interface ISettingsVewModel : IDatabaseSettings
    {

    }

    public interface IDatabaseSettings
    {
        public bool IsLocalDatabase { get; }
        public string UserId { get; }
        public string Password { get; }
        public string IP { get; }
        public int Port { get; }
    }

    public interface IGeneralSettings
    {
        public bool AutoSave { get; }
    }
}
