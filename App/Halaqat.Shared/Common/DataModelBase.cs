using CommunityToolkit.Mvvm.ComponentModel;

namespace Halaqat.Shared.Common
{
    public abstract class DataModelBase<TModel>(TModel model) : ObservableValidator where TModel : class
    {
        public bool IsValid => !HasErrors;
        public abstract void Update(TModel model);
        public TModel Model { get; } = model;
    }
}
