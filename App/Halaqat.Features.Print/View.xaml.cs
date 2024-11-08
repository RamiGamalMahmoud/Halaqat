using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
using System.Windows;

namespace Halaqat.Features.Print
{
    internal partial class View : Window
    {
        public View()
        {
            InitializeComponent();
        }

        public View(string reportPath, IEnumerable<ReportParameter> reportParameters = null, Dictionary<string, object> dataSources = null) : this()
        {
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.LocalReport.ReportPath = reportPath;
            reportViewer.LocalReport.EnableExternalImages = true;

            if (reportParameters is not null)
            {
                reportViewer.LocalReport.SetParameters(reportParameters);
            }


            if (dataSources is not null)
            {
                reportViewer.LocalReport.DataSources.Clear();
                foreach (KeyValuePair<string, object> keyValuePair in dataSources)
                {
                    reportViewer.LocalReport.DataSources.Add(new ReportDataSource(keyValuePair.Key, keyValuePair.Value));
                }
            }

            reportViewer.RefreshReport();
        }
    }
}
