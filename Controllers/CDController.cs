#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EF_MOM_3_2.Data;
using EF_MOM_3_2.Models;

namespace EF_MOM_3_2.Controllers
{
    public class CDController : Controller
    {
        private readonly DataContext _context;

        public CDController(DataContext context)
        {
            _context = context;
        }

        // GET: CD
        public async Task<IActionResult> Index(string search)
        {
            var dataContext = _context.CD.Include(c => c.Artist).Include(c => c.Customer);
            if (!String.IsNullOrEmpty(search))
            {
                var result = await dataContext.Where(CD => CD.Album.ToLower().Contains(search.ToLower())).ToListAsync();
                return View(result);
            }
            else
            {
                var result = await dataContext.ToListAsync();
                return View(result);
            }
        }

        // GET: CD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cD = await _context.CD
                .Include(c => c.Artist)
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(m => m.CDId == id);
            if (cD == null)
            {
                return NotFound();
            }

            return View(cD);
        }

        // GET: CD/Create
        public IActionResult Create()
        {
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "ArtistId");
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId");
            return View();
        }

        // POST: CD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CDId,Album,ArtistId,CustomerId,DateLent")] CD cD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "ArtistId", cD.ArtistId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", cD.CustomerId);
            return View(cD);
        }

        // GET: CD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cD = await _context.CD.FindAsync(id);
            if (cD == null)
            {
                return NotFound();
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "ArtistId", cD.ArtistId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", cD.CustomerId);
            return View(cD);
        }

        // POST: CD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CDId,Album,ArtistId,CustomerId,DateLent")] CD cD)
        {
            if (id != cD.CDId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CDExists(cD.CDId))
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
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "ArtistId", cD.ArtistId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", cD.CustomerId);
            return View(cD);
        }

        // GET: CD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cD = await _context.CD
                .Include(c => c.Artist)
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(m => m.CDId == id);
            if (cD == null)
            {
                return NotFound();
            }

            return View(cD);
        }

        // POST: CD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cD = await _context.CD.FindAsync(id);
            _context.CD.Remove(cD);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CDExists(int id)
        {
            return _context.CD.Any(e => e.CDId == id);
        }
    }
}
