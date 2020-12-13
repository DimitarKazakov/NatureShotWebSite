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

    public class LocationsController : AdministrationController
    {
        private readonly IRepository<Location> locationRepository;

        public LocationsController(IRepository<Location> locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        // GET: Locations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = this.locationRepository.All().Include(l => l.Country).Include(l => l.Town);
            return this.View(await applicationDbContext.ToListAsync());
        }

        // GET: Locations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var location = await this.locationRepository.All()
                .Include(l => l.Country)
                .Include(l => l.Town)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (location == null)
            {
                return this.NotFound();
            }

            return this.View(location);
        }

        // GET: Locations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var location = await this.locationRepository.All()
                .Include(l => l.Country)
                .Include(l => l.Town)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (location == null)
            {
                return this.NotFound();
            }

            return this.View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var location = this.locationRepository.All().FirstOrDefault(x => x.Id == id);
            this.locationRepository.Delete(location);
            await this.locationRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool LocationExists(int id)
        {
            return this.locationRepository.All().Any(e => e.Id == id);
        }
    }
}
