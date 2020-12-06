namespace NatureShot.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using NatureShot.Web.ViewModels.Report;

    public interface IReportService
    {
        Task CreateReport(ReportInputModel input);
    }
}
