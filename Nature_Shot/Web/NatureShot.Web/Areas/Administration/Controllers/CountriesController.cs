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

    public class CountriesController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Country> countryRepository;

        public CountriesController(IDeletableEntityRepository<Country> countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        // GET: Countries
        public async Task<IActionResult> Index()
        {
            return this.View(await this.countryRepository.AllWithDeleted().ToListAsync());
        }

        // GET: Countries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var country = await this.countryRepository.AllWithDeleted()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (country == null)
            {
                return this.NotFound();
            }

            return this.View(country);
        }

        // GET: Countries/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Countries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Country country)
        {
            if (this.ModelState.IsValid)
            {
                await this.countryRepository.AddAsync(country);
                await this.countryRepository.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(country);
        }

        // GET: Countries/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var country = this.countryRepository.AllWithDeleted().FirstOrDefault(x => x.Id == id);
            if (country == null)
            {
                return this.NotFound();
            }

            return this.View(country);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Country country)
        {
            if (id != country.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.countryRepository.Update(country);
                    await this.countryRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.CountryExists(country.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(country);
        }

        // GET: Countries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var country = await countryRepository.AllWithDeleted()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (country == null)
            {
                return this.NotFound();
            }

            return this.View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var country = this.countryRepository.AllWithDeleted().FirstOrDefault(x => x.Id == id);
            this.countryRepository.Delete(country);
            await this.countryRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool CountryExists(int id)
        {
            return this.countryRepository.AllWithDeleted().Any(e => e.Id == id);
        }
    }
}
