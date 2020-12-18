namespace NatureShot.Services.Data.Contracts
{
    using System;
    using System.Threading.Tasks;

    using NatureShot.Web.ViewModels.Report;

    public interface IReportService
    {
        Task CreateReport(ReportInputModel input);
    }
}
