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
    public class SchemeModuleController : Controller
    {
        private readonly cascadeContext _context;

        public SchemeModuleController(cascadeContext context)
        {
            _context = context;
        }

        // GET: SchemeModule
        public async Task<IActionResult> Index()
        {
            var cascadeContext = _context.SchemeModules.Include(s => s.Module).Include(s => s.Scheme);
            return View(await cascadeContext.ToListAsync());
        }

        // GET: SchemeModule/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schemeModule = await _context.SchemeModules
                .Include(s => s.Module)
                .Include(s => s.Scheme)
                .FirstOrDefaultAsync(m => m.SchemeModuleId == id);
            if (schemeModule == null)
            {
                return NotFound();
            }

            return View(schemeModule);
        }

        // GET: SchemeModule/Create
        public IActionResult Create()
        {
            ViewData["ModuleId"] = new SelectList(_context.Modules, "ModuleId", "ModuleId");
            ViewData["SchemeId"] = new SelectList(_context.Schemes, "SchemeId", "SchemeId");
            return View();
        }

        // POST: SchemeModule/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SchemeModuleId,SchemeId,ModuleId,ModuleType")] SchemeModule schemeModule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schemeModule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModuleId"] = new SelectList(_context.Modules, "ModuleId", "ModuleId", schemeModule.ModuleId);
            ViewData["SchemeId"] = new SelectList(_context.Schemes, "SchemeId", "SchemeId", schemeModule.SchemeId);
            return View(schemeModule);
        }

        // GET: SchemeModule/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schemeModule = await _context.SchemeModules.FindAsync(id);
            if (schemeModule == null)
            {
                return NotFound();
            }
            ViewData["ModuleId"] = new SelectList(_context.Modules, "ModuleId", "ModuleId", schemeModule.ModuleId);
            ViewData["SchemeId"] = new SelectList(_context.Schemes, "SchemeId", "SchemeId", schemeModule.SchemeId);
            return View(schemeModule);
        }

        // POST: SchemeModule/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SchemeModuleId,SchemeId,ModuleId,ModuleType")] SchemeModule schemeModule)
        {
            if (id != schemeModule.SchemeModuleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schemeModule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchemeModuleExists(schemeModule.SchemeModuleId))
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
            ViewData["ModuleId"] = new SelectList(_context.Modules, "ModuleId", "ModuleId", schemeModule.ModuleId);
            ViewData["SchemeId"] = new SelectList(_context.Schemes, "SchemeId", "SchemeId", schemeModule.SchemeId);
            return View(schemeModule);
        }

        // GET: SchemeModule/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schemeModule = await _context.SchemeModules
                .Include(s => s.Module)
                .Include(s => s.Scheme)
                .FirstOrDefaultAsync(m => m.SchemeModuleId == id);
            if (schemeModule == null)
            {
                return NotFound();
            }

            return View(schemeModule);
        }

        // POST: SchemeModule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schemeModule = await _context.SchemeModules.FindAsync(id);
            _context.SchemeModules.Remove(schemeModule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchemeModuleExists(int id)
        {
            return _context.SchemeModules.Any(e => e.SchemeModuleId == id);
        }
    }
}
