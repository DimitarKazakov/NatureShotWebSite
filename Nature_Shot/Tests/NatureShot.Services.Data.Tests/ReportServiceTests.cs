namespace NatureShot.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Moq;
    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using NatureShot.Services.Data;
    using Xunit;

    public class ReportServiceTests
    {
        public ReportServiceTests()
        {
        }

        [Fact]
        public void CreateReportShouldAddTheReport()
        {
            var list = new List<Report>();

            var repository = new Mock<IDeletableEntityRepository<Report>>();
            repository.Setup(r => r.AddAsync(It.IsAny<Report>())).Callback((Report report) => list.Add(report));
            var service = new ReportService(repository.Object);

            var react = service.CreateReport(new Web.ViewModels.Report.ReportInputModel
            {
                Content = "TestContent",
                Subject = "Testing",
                PostId = "1",
            });

            Assert.Single(list);
            Assert.Equal("TestContent", list[0].Content);
            Assert.Equal("Testing", list[0].Subject);
            Assert.Equal(1, list[0].PostId);
            repository.Verify(x => x.AddAsync(It.IsAny<Report>()), Times.Once);
        }
    }
}
