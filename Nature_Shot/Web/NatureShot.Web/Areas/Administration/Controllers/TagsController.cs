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

    public class TagsController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Tag> tagRepository;

        public TagsController(IDeletableEntityRepository<Tag> tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        // GET: Tags
        public async Task<IActionResult> Index()
        {
            return this.View(await this.tagRepository.AllWithDeleted().ToListAsync());
        }

        // GET: Tags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var tag = await this.tagRepository.AllWithDeleted()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tag == null)
            {
                return this.NotFound();
            }

            return this.View(tag);
        }

        // GET: Tags/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Tags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Tag tag)
        {
            if (this.ModelState.IsValid)
            {
                await this.tagRepository.AddAsync(tag);
                await this.tagRepository.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(tag);
        }

        // GET: Tags/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var tag = this.tagRepository.AllWithDeleted().FirstOrDefault(x => x.Id == id);
            if (tag == null)
            {
                return this.NotFound();
            }

            return this.View(tag);
        }

        // POST: Tags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Tag tag)
        {
            if (id != tag.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.tagRepository.Update(tag);
                    await this.tagRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.TagExists(tag.Id))
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

            return this.View(tag);
        }

        // GET: Tags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var tag = await this.tagRepository.AllWithDeleted()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tag == null)
            {
                return this.NotFound();
            }

            return this.View(tag);
        }

        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tag = this.tagRepository.AllWithDeleted().FirstOrDefault(x => x.Id == id);
            this.tagRepository.Delete(tag);
            await this.tagRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool TagExists(int id)
        {
            return this.tagRepository.AllWithDeleted().Any(e => e.Id == id);
        }
    }
}
