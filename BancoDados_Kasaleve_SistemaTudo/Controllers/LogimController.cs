using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BancoDados_Kasaleve_SistemaTudo.Models;

namespace BancoDados_Kasaleve_SistemaTudo.Controllers
{
    public class LogimController : Controller
    {
        private readonly Contexto _context;

        public LogimController(Contexto context)
        {
            _context = context;
        }

        // GET: Logim
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Logim.Include(l => l.Cargo);
            return View(await contexto.ToListAsync());
        }

        // GET: Logim/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logim = await _context.Logim
                .Include(l => l.Cargo)
                .FirstOrDefaultAsync(m => m.LogimId == id);
            if (logim == null)
            {
                return NotFound();
            }

            return View(logim);
        }

        // GET: Logim/Create
        public IActionResult Create()
        {
            ViewData["cargoId"] = new SelectList(_context.Cargo, "cargoId", "cargoId");
            return View();
        }

        // POST: Logim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LogimId,LogimNome,LogimSenha,LogimEmail,cargoId")] Logim logim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["cargoId"] = new SelectList(_context.Cargo, "cargoId", "cargoId", logim.cargoId);
            return View(logim);
        }

        // GET: Logim/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logim = await _context.Logim.FindAsync(id);
            if (logim == null)
            {
                return NotFound();
            }
            ViewData["cargoId"] = new SelectList(_context.Cargo, "cargoId", "cargoId", logim.cargoId);
            return View(logim);
        }

        // POST: Logim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LogimId,LogimNome,LogimSenha,LogimEmail,cargoId")] Logim logim)
        {
            if (id != logim.LogimId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogimExists(logim.LogimId))
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
            ViewData["cargoId"] = new SelectList(_context.Cargo, "cargoId", "cargoId", logim.cargoId);
            return View(logim);
        }

        // GET: Logim/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logim = await _context.Logim
                .Include(l => l.Cargo)
                .FirstOrDefaultAsync(m => m.LogimId == id);
            if (logim == null)
            {
                return NotFound();
            }

            return View(logim);
        }

        // POST: Logim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var logim = await _context.Logim.FindAsync(id);
            if (logim != null)
            {
                _context.Logim.Remove(logim);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogimExists(int id)
        {
            return _context.Logim.Any(e => e.LogimId == id);
        }
    }
}
