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

namespace NatureShot.Web.Areas.Administration.Controllers
{
    public class CommentsController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Comment> commentRepository;

        public CommentsController(IDeletableEntityRepository<Comment> commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        // GET: Comments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = this.commentRepository.AllWithDeleted().Include(c => c.Post).Include(c => c.UserPosted);
            return this.View(await applicationDbContext.ToListAsync());
        }

        // GET: Comments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var comment = await this.commentRepository.AllWithDeleted()
                .Include(c => c.Post)
                .Include(c => c.UserPosted)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comment == null)
            {
                return this.NotFound();
            }

            return this.View(comment);
        }

        // GET: Comments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var comment = await this.commentRepository.AllWithDeleted()
                .Include(c => c.Post)
                .Include(c => c.UserPosted)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comment == null)
            {
                return this.NotFound();
            }

            return this.View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = this.commentRepository.AllWithDeleted().FirstOrDefault(x => x.Id == id);
            this.commentRepository.Delete(comment);
            await this.commentRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool CommentExists(int id)
        {
            return this.commentRepository.AllWithDeleted().Any(e => e.Id == id);
        }
    }
}
