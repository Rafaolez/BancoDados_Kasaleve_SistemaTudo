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
    public class TipoProdutoController : Controller
    {
        private readonly Contexto _context;

        public TipoProdutoController(Contexto context)
        {
            _context = context;
        }

        // GET: TipoProduto
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoProduto.ToListAsync());
        }

        // GET: TipoProduto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProduto = await _context.TipoProduto
                .FirstOrDefaultAsync(m => m.tipoProdutoId == id);
            if (tipoProduto == null)
            {
                return NotFound();
            }

            return View(tipoProduto);
        }

        // GET: TipoProduto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoProduto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("tipoProdutoId,tipoProdutoNome")] TipoProduto tipoProduto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoProduto);
        }

        // GET: TipoProduto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProduto = await _context.TipoProduto.FindAsync(id);
            if (tipoProduto == null)
            {
                return NotFound();
            }
            return View(tipoProduto);
        }

        // POST: TipoProduto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("tipoProdutoId,tipoProdutoNome")] TipoProduto tipoProduto)
        {
            if (id != tipoProduto.tipoProdutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoProduto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoProdutoExists(tipoProduto.tipoProdutoId))
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
            return View(tipoProduto);
        }

        // GET: TipoProduto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProduto = await _context.TipoProduto
                .FirstOrDefaultAsync(m => m.tipoProdutoId == id);
            if (tipoProduto == null)
            {
                return NotFound();
            }

            return View(tipoProduto);
        }

        // POST: TipoProduto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoProduto = await _context.TipoProduto.FindAsync(id);
            if (tipoProduto != null)
            {
                _context.TipoProduto.Remove(tipoProduto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoProdutoExists(int id)
        {
            return _context.TipoProduto.Any(e => e.tipoProdutoId == id);
        }
    }
}
