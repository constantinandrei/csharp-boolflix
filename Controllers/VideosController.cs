using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using csharp_boolflix.Areas.Identity.Data;
using csharp_boolflix.Models;

namespace csharp_boolflix.Controllers
{
    public class VideosController : Controller
    {
        private readonly IdentityDataContext _context;

        public VideosController(IdentityDataContext context)
        {
            _context = context;
        }

        // GET: Videos
        public async Task<IActionResult> Index()
        {
            var identityDataContext = _context.Video.Include(v => v.Content);
            return View(await identityDataContext.ToListAsync());
        }

        // GET: Videos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Video == null)
            {
                return NotFound();
            }

            var video = await _context.Video
                .Include(v => v.Content)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // GET: Videos/Create
        public IActionResult Create()
        {
            ViewData["ContentId"] = new SelectList(_context.Set<Content>(), "Id", "Discriminator");
            return View();
        }

        // POST: Videos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContentId,LinkToVideo,Length")] Video video)
        {
            if (ModelState.IsValid)
            {
                _context.Add(video);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContentId"] = new SelectList(_context.Set<Content>(), "Id", "Discriminator", video.ContentId);
            return View(video);
        }

        // GET: Videos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Video == null)
            {
                return NotFound();
            }

            var video = await _context.Video.FindAsync(id);
            if (video == null)
            {
                return NotFound();
            }
            ViewData["ContentId"] = new SelectList(_context.Set<Content>(), "Id", "Discriminator", video.ContentId);
            return View(video);
        }

        // POST: Videos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContentId,LinkToVideo,Length")] Video video)
        {
            if (id != video.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(video);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoExists(video.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContentId"] = new SelectList(_context.Set<Content>(), "Id", "Discriminator", video.ContentId);
            return View(video);
        }

        // GET: Videos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Video == null)
            {
                return NotFound();
            }

            var video = await _context.Video
                .Include(v => v.Content)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Video == null)
            {
                return Problem("Entity set 'IdentityDataContext.Video'  is null.");
            }
            var video = await _context.Video.FindAsync(id);
            if (video != null)
            {
                _context.Video.Remove(video);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideoExists(int id)
        {
          return _context.Video.Any(e => e.Id == id);
        }
    }
}
