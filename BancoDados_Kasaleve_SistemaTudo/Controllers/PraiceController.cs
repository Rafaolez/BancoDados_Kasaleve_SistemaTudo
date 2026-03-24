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
    public class PraiceController : Controller
    {
        private readonly Contexto _context;

        public PraiceController(Contexto context)
        {
            _context = context;
        }

        // GET: Praice
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Praice.Include(p => p.TipoProduto);
            return View(await contexto.ToListAsync());
        }

        // GET: Praice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var praice = await _context.Praice
                .Include(p => p.TipoProduto)
                .FirstOrDefaultAsync(m => m.praiceId == id);
            if (praice == null)
            {
                return NotFound();
            }

            return View(praice);
        }

        // GET: Praice/Create
        public IActionResult Create()
        {
            ViewData["TipoProdutoId"] = new SelectList(_context.TipoProduto, "tipoProdutoId", "tipoProdutoId");
            return View();
        }

        // POST: Praice/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("praiceId,praiceValor,TipoProdutoId")] Praice praice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(praice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoProdutoId"] = new SelectList(_context.TipoProduto, "tipoProdutoId", "tipoProdutoId", praice.TipoProdutoId);
            return View(praice);
        }

        // GET: Praice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var praice = await _context.Praice.FindAsync(id);
            if (praice == null)
            {
                return NotFound();
            }
            ViewData["TipoProdutoId"] = new SelectList(_context.TipoProduto, "tipoProdutoId", "tipoProdutoId", praice.TipoProdutoId);
            return View(praice);
        }

        // POST: Praice/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("praiceId,praiceValor,TipoProdutoId")] Praice praice)
        {
            if (id != praice.praiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(praice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PraiceExists(praice.praiceId))
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
            ViewData["TipoProdutoId"] = new SelectList(_context.TipoProduto, "tipoProdutoId", "tipoProdutoId", praice.TipoProdutoId);
            return View(praice);
        }

        // GET: Praice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var praice = await _context.Praice
                .Include(p => p.TipoProduto)
                .FirstOrDefaultAsync(m => m.praiceId == id);
            if (praice == null)
            {
                return NotFound();
            }

            return View(praice);
        }

        // POST: Praice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var praice = await _context.Praice.FindAsync(id);
            if (praice != null)
            {
                _context.Praice.Remove(praice);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PraiceExists(int id)
        {
            return _context.Praice.Any(e => e.praiceId == id);
        }
    }
}
