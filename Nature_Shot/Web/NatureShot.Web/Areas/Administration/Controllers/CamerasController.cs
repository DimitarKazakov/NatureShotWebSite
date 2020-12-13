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

    public class CamerasController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Camera> cameraRepository;

        public CamerasController(IDeletableEntityRepository<Camera> cameraRepository)
        {
            this.cameraRepository = cameraRepository;
        }

        // GET: Cameras
        public async Task<IActionResult> Index()
        {
            return this.View(await this.cameraRepository.AllWithDeleted().ToListAsync());
        }

        // GET: Cameras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var camera = await this.cameraRepository.AllWithDeleted()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (camera == null)
            {
                return this.NotFound();
            }

            return this.View(camera);
        }

        // GET: Cameras/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Cameras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Model,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Camera camera)
        {
            if (this.ModelState.IsValid)
            {
                await this.cameraRepository.AddAsync(camera);
                await this.cameraRepository.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(camera);
        }

        // GET: Cameras/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var camera = this.cameraRepository.AllWithDeleted().FirstOrDefault(x => x.Id == id);
            if (camera == null)
            {
                return this.NotFound();
            }

            return this.View(camera);
        }

        // POST: Cameras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Model,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Camera camera)
        {
            if (id != camera.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.cameraRepository.Update(camera);
                    await this.cameraRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.CameraExists(camera.Id))
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

            return this.View(camera);
        }

        // GET: Cameras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var camera = await this.cameraRepository.AllWithDeleted()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (camera == null)
            {
                return this.NotFound();
            }

            return this.View(camera);
        }

        // POST: Cameras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var camera = this.cameraRepository.AllWithDeleted().FirstOrDefault(x => x.Id == id);
            this.cameraRepository.Delete(camera);
            await this.cameraRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool CameraExists(int id)
        {
            return this.cameraRepository.AllWithDeleted().Any(e => e.Id == id);
        }
    }
}
