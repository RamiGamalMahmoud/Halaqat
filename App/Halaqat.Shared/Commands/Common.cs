using MediatR;
using System.Collections.Generic;
using Halaqat.Shared.Common;

namespace Halaqat.Shared.Commands
{
    public static class Common
    {
        internal record UpdateModelCommand<T1, T2> : IRequest;

        public record Get<TModel>(int Id) : IRequest<Result<TModel>> where TModel : class;
        public record GetAllCommand<TModel>(bool Reload) : IRequest<IEnumerable<TModel>>;

        public record ShowCreateModelViewCommand<TModel>() : IRequest;
        public record CreateModelCommand<TModel, TDataModel>(TDataModel DataModel) : IRequest<Result<TModel>> where TModel : class;

        public record ShowEditModelViewCommand<TModel>(TModel Model) : IRequest;
        public record UpdateModelCommand<TDataModel>(TDataModel DataModel) : IRequest<Result>;

        public record RemoveModelCommand<TModel>(TModel Model) : IRequest<Result>;
        public record ShowSettingsViewCommand() : IRequest;
        public record ShowPrintCommand(string ReportName, Dictionary<string, string> Parameters = null, Dictionary<string, object> DataSources = null) : IRequest;
        public record DirectPrintCommand(string ReportName, string PrinterName, Dictionary<string, string> Parameters = null, Dictionary<string, object> DataSources = null) : IRequest;
    }
}
