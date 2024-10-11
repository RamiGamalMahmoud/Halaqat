using Halaqat.Shared;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Halaqat.Data
{
    public abstract class RepositoryBase<TModel, TDataModel>(IAppDbContextFactory appDbContextFactory) where TModel : class where TDataModel : class
    {
        protected void SetEntities(IEnumerable<TModel> entities)
        {
            _entities = new ObservableCollection<TModel>(entities);
            _isLoaded = true;
        }

        public abstract Task<IEnumerable<TModel>> GetAll(bool reload);
        public abstract Task<Result<TModel>> Create(TDataModel dataModel);
        public abstract Task<Result> Update(TDataModel dataModel);
        public abstract Task<Result> Remove(TModel model);

        protected readonly IAppDbContextFactory _dbContextFactory = appDbContextFactory;
        protected static ObservableCollection<TModel> _entities;
        protected static bool _isLoaded;
    }
}
