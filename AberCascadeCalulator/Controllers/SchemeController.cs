using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AberCascadeCalulator.Data;
using AberCascadeCalulator.Models;

namespace AberCascadeCalulator.Controllers
{
    public class SchemeController : Controller
    {
        private readonly cascadeContext _context;

        public SchemeController(cascadeContext context)
        {
            _context = context;
        }

        // GET: Scheme
        public async Task<IActionResult> Index()
        {
            return View(await _context.Schemes.ToListAsync());
        }

        // GET: Scheme/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheme = await _context.Schemes
                .FirstOrDefaultAsync(m => m.SchemeId == id);
            if (scheme == null)
            {
                return NotFound();
            }

            return View(scheme);
        }

        // GET: Scheme/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Scheme/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SchemeId,Title,Award,Department,UndergraduateOrPostgraduate,SchemeType,Year,Duration,Url")] Scheme scheme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scheme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(scheme);
        }

        // GET: Scheme/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheme = await _context.Schemes.FindAsync(id);
            if (scheme == null)
            {
                return NotFound();
            }
            return View(scheme);
        }

        // POST: Scheme/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SchemeId,Title,Award,Department,UndergraduateOrPostgraduate,SchemeType,Year,Duration,Url")] Scheme scheme)
        {
            if (id != scheme.SchemeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scheme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchemeExists(scheme.SchemeId))
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
            return View(scheme);
        }

        // GET: Scheme/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheme = await _context.Schemes
                .FirstOrDefaultAsync(m => m.SchemeId == id);
            if (scheme == null)
            {
                return NotFound();
            }

            return View(scheme);
        }

        // POST: Scheme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var scheme = await _context.Schemes.FindAsync(id);
            _context.Schemes.Remove(scheme);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchemeExists(string id)
        {
            return _context.Schemes.Any(e => e.SchemeId == id);
        }
    }
}
