namespace Halaqat.Features.Settings
{
    internal partial class ViewModel
    {
        public bool AutoSave
        {
            get => _settings.AutoSave;
            set => SetProperty(_settings.AutoSave, value, _settings, (o, v) => o.AutoSave = v);
        }
    }
}
