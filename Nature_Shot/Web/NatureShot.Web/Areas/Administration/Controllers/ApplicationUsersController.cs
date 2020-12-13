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
    using NatureShot.Data.Models;

    public class ApplicationUsersController : AdministrationController
    {
        private readonly ApplicationDbContext context;

        public ApplicationUsersController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: ApplicationUsers
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Users.ToListAsync());
        }

        // GET: ApplicationUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var applicationUser = await this.context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return this.NotFound();
            }

            return this.View(applicationUser);
        }

        // GET: ApplicationUsers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var applicationUser = await this.context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return this.NotFound();
            }

            return this.View(applicationUser);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var applicationUser = this.context.Users.FirstOrDefault(x => x.Id == id);
            applicationUser.IsDeleted = true;
            applicationUser.DeletedOn = DateTime.UtcNow;
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool ApplicationUserExists(string id)
        {
            return this.context.Users.Any(e => e.Id == id);
        }
    }
}
