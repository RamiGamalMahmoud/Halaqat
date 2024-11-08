using Halaqat.Shared.Commands;
using MediatR;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Print.CommandHandlers
{
    internal class ShowPrintCommandHandler : IRequestHandler<Shared.Commands.Common.ShowPrintCommand>
    {
        public Task Handle(Common.ShowPrintCommand request, CancellationToken cancellationToken)
        {
            string reportPath = System.IO.Path.Combine(Environment.CurrentDirectory, "Reports", $"{request.ReportName}.rdlc");
            IEnumerable<ReportParameter> reportParameters = LocalReportHelpers.GetReportParameters(request.Parameters);

            View view = new View(reportPath, reportParameters, request.DataSources);
            view.Show();
            return Task.CompletedTask;
        }
    }
}
