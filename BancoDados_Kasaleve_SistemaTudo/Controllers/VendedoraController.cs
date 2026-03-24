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
    public class VendedoraController : Controller
    {
        private readonly Contexto _context;

        public VendedoraController(Contexto context)
        {
            _context = context;
        }

        // GET: Vendedora
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vendedora.ToListAsync());
        }

        // GET: Vendedora/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedora = await _context.Vendedora
                .FirstOrDefaultAsync(m => m.vendedoraId == id);
            if (vendedora == null)
            {
                return NotFound();
            }

            return View(vendedora);
        }

        // GET: Vendedora/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vendedora/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("vendedoraId,vendedoraNome")] Vendedora vendedora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendedora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendedora);
        }

        // GET: Vendedora/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedora = await _context.Vendedora.FindAsync(id);
            if (vendedora == null)
            {
                return NotFound();
            }
            return View(vendedora);
        }

        // POST: Vendedora/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("vendedoraId,vendedoraNome")] Vendedora vendedora)
        {
            if (id != vendedora.vendedoraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendedora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendedoraExists(vendedora.vendedoraId))
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
            return View(vendedora);
        }

        // GET: Vendedora/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedora = await _context.Vendedora
                .FirstOrDefaultAsync(m => m.vendedoraId == id);
            if (vendedora == null)
            {
                return NotFound();
            }

            return View(vendedora);
        }

        // POST: Vendedora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendedora = await _context.Vendedora.FindAsync(id);
            if (vendedora != null)
            {
                _context.Vendedora.Remove(vendedora);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendedoraExists(int id)
        {
            return _context.Vendedora.Any(e => e.vendedoraId == id);
        }
    }
}
