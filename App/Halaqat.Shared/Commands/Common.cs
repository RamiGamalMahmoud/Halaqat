using MediatR;
using System.Collections.Generic;

namespace Halaqat.Shared.Commands
{
    public static class Common
    {
        internal class UpdateModelCommand<T1, T2>
        {
        }

        public record Get<TModel>(int Id) : IRequest<Result<TModel>> where TModel : class;
        public record GetAllCommand<TModel>(bool Reload) : IRequest<IEnumerable<TModel>>;

        public record ShowCreateModelViewCommand<TModel>() : IRequest;
        public record CreateModelCommand<TModel, TDataModel>(TDataModel DataModel) : IRequest<Result<TModel>> where TModel : class;

        public record ShowEditModelViewCommand<TModel>(TModel Model) : IRequest;
        public record UpdateModelCommand<TDataModel>(TDataModel DataModel) : IRequest<Result>;

        public record RemoveModelCommand<TModel>(TModel Model) : IRequest<Result>;
    }
}
