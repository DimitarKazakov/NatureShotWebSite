namespace NatureShot.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using NatureShot.Data;
    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;

    public class ReportsController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Report> reportRepository;

        public ReportsController(IDeletableEntityRepository<Report> reportRepository)
        {
            this.reportRepository = reportRepository;
        }

        // GET: Reports
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = this.reportRepository.AllWithDeleted().Include(r => r.Post);
            return this.View(await applicationDbContext.ToListAsync());
        }

        // GET: Reports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var report = await this.reportRepository.AllWithDeleted()
                .Include(r => r.Post)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (report == null)
            {
                return this.NotFound();
            }

            return this.View(report);
        }

        // GET: Reports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var report = await this.reportRepository.AllWithDeleted()
                .Include(r => r.Post)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (report == null)
            {
                return this.NotFound();
            }

            return this.View(report);
        }

        // POST: Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var report = this.reportRepository.AllWithDeleted().FirstOrDefault(x => x.Id == id);
            this.reportRepository.Delete(report);
            await this.reportRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool ReportExists(int id)
        {
            return this.reportRepository.AllWithDeleted().Any(e => e.Id == id);
        }
    }
}
