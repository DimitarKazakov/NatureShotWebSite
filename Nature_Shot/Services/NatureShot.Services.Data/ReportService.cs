namespace NatureShot.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using NatureShot.Web.ViewModels.Report;

    public class ReportService : IReportService
    {
        private readonly IDeletableEntityRepository<Report> reportRepository;

        public ReportService(IDeletableEntityRepository<Report> reportRepository)
        {
            this.reportRepository = reportRepository;
        }

        public async Task CreateReport(ReportInputModel input)
        {
            await this.reportRepository.AddAsync(new Report
            {
                Content = input.Content,
                Subject = input.Subject,
                PostId = int.Parse(input.PostId),
            });

            await this.reportRepository.SaveChangesAsync();
        }
    }
}
