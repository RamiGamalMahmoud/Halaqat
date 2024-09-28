using Halaqat.Data;
using Halaqat.Shared;
using Halaqat.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Halaqat.Features.Circles
{
    internal class Repository(IAppDbContextFactory appDbContextFactory) : RepositoryBase<Circle, CircleDataModel>(appDbContextFactory)
    {
        public override Task<IEnumerable<Circle>> GetAll(bool reload)
        {
            throw new System.NotImplementedException();
        }

        public override Task<Result<Circle>> Create(CircleDataModel dataModel)
        {
            throw new System.NotImplementedException();
        }

        public override Task<Result> Update(CircleDataModel dataModel)
        {
            throw new System.NotImplementedException();
        }

        public override Task<Result> Remove(Circle circle)
        {
            throw new System.NotImplementedException();
        }
    }
}
