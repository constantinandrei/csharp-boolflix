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
    public class SeasonsController : Controller
    {
        private readonly IdentityDataContext _context;

        public SeasonsController(IdentityDataContext context)
        {
            _context = context;
        }

        // GET: Seasons
        public async Task<IActionResult> Index()
        {
            var identityDataContext = _context.Seasons.Include(s => s.Series);
            return View(await identityDataContext.ToListAsync());
        }

        // GET: Seasons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Seasons == null)
            {
                return NotFound();
            }

            var season = await _context.Seasons
                .Include(s => s.Series)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (season == null)
            {
                return NotFound();
            }

            return View(season);
        }

        // GET: Seasons/Create
        public IActionResult Create()
        {
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "Discriminator");
            return View();
        }

        // POST: Seasons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SeriesId")] Season season)
        {
            if (ModelState.IsValid)
            {
                _context.Add(season);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "Discriminator", season.SeriesId);
            return View(season);
        }

        // GET: Seasons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Seasons == null)
            {
                return NotFound();
            }

            var season = await _context.Seasons.FindAsync(id);
            if (season == null)
            {
                return NotFound();
            }
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "Discriminator", season.SeriesId);
            return View(season);
        }

        // POST: Seasons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SeriesId")] Season season)
        {
            if (id != season.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(season);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeasonExists(season.Id))
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
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "Discriminator", season.SeriesId);
            return View(season);
        }

        // GET: Seasons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Seasons == null)
            {
                return NotFound();
            }

            var season = await _context.Seasons
                .Include(s => s.Series)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (season == null)
            {
                return NotFound();
            }

            return View(season);
        }

        // POST: Seasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Seasons == null)
            {
                return Problem("Entity set 'IdentityDataContext.Seasons'  is null.");
            }
            var season = await _context.Seasons.FindAsync(id);
            if (season != null)
            {
                _context.Seasons.Remove(season);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeasonExists(int id)
        {
          return _context.Seasons.Any(e => e.Id == id);
        }
    }
}
