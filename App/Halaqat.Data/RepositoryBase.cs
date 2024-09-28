﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Halaqat.Data
{
    public abstract class RepositoryBase<TModel>(IAppDbContextFactory appDbContextFactory)
    {
        protected void SetEntities(IEnumerable<TModel> entities)
        {
            _entities = new ObservableCollection<TModel>(entities);
            _isLoaded = true;
        }

        public abstract Task<IEnumerable<TModel>> GetAll(bool reload);

        protected readonly IAppDbContextFactory _dbContextFactory = appDbContextFactory;
        protected static ObservableCollection<TModel> _entities;
        protected static bool _isLoaded;
    }
}
