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
    public class OrcamentoController : Controller
    {
        private readonly Contexto _context;

        public OrcamentoController(Contexto context)
        {
            _context = context;
        }

        // GET: Orcamento
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Orcamento.Include(o => o.Cliente).Include(o => o.Praice).Include(o => o.Vendedora);
            return View(await contexto.ToListAsync());
        }

        // GET: Orcamento/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orcamento = await _context.Orcamento
                .Include(o => o.Cliente)
                .Include(o => o.Praice)
                .Include(o => o.Vendedora)
                .FirstOrDefaultAsync(m => m.orcamentoId == id);
            if (orcamento == null)
            {
                return NotFound();
            }

            return View(orcamento);
        }

        // GET: Orcamento/Create
        public IActionResult Create()
        {
            ViewData["clienteId"] = new SelectList(_context.Cliente, "clienteId", "clienteId");
            ViewData["praiceId"] = new SelectList(_context.Praice, "praiceId", "praiceId");
            ViewData["vendedoraId"] = new SelectList(_context.Vendedora, "vendedoraId", "vendedoraId");
            return View();
        }

        // POST: Orcamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("orcamentoId,Nonce,clienteId,praiceId,vendedoraId,orcamnetoCorAluminio,orcamentoCorCorda,orcamentoCorTecido")] Orcamento orcamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orcamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["clienteId"] = new SelectList(_context.Cliente, "clienteId", "clienteId", orcamento.clienteId);
            ViewData["praiceId"] = new SelectList(_context.Praice, "praiceId", "praiceId", orcamento.praiceId);
            ViewData["vendedoraId"] = new SelectList(_context.Vendedora, "vendedoraId", "vendedoraId", orcamento.vendedoraId);
            return View(orcamento);
        }

        // GET: Orcamento/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orcamento = await _context.Orcamento.FindAsync(id);
            if (orcamento == null)
            {
                return NotFound();
            }
            ViewData["clienteId"] = new SelectList(_context.Cliente, "clienteId", "clienteId", orcamento.clienteId);
            ViewData["praiceId"] = new SelectList(_context.Praice, "praiceId", "praiceId", orcamento.praiceId);
            ViewData["vendedoraId"] = new SelectList(_context.Vendedora, "vendedoraId", "vendedoraId", orcamento.vendedoraId);
            return View(orcamento);
        }

        // POST: Orcamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("orcamentoId,Nonce,clienteId,praiceId,vendedoraId,orcamnetoCorAluminio,orcamentoCorCorda,orcamentoCorTecido")] Orcamento orcamento)
        {
            if (id != orcamento.orcamentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orcamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrcamentoExists(orcamento.orcamentoId))
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
            ViewData["clienteId"] = new SelectList(_context.Cliente, "clienteId", "clienteId", orcamento.clienteId);
            ViewData["praiceId"] = new SelectList(_context.Praice, "praiceId", "praiceId", orcamento.praiceId);
            ViewData["vendedoraId"] = new SelectList(_context.Vendedora, "vendedoraId", "vendedoraId", orcamento.vendedoraId);
            return View(orcamento);
        }

        // GET: Orcamento/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orcamento = await _context.Orcamento
                .Include(o => o.Cliente)
                .Include(o => o.Praice)
                .Include(o => o.Vendedora)
                .FirstOrDefaultAsync(m => m.orcamentoId == id);
            if (orcamento == null)
            {
                return NotFound();
            }

            return View(orcamento);
        }

        // POST: Orcamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var orcamento = await _context.Orcamento.FindAsync(id);
            if (orcamento != null)
            {
                _context.Orcamento.Remove(orcamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrcamentoExists(string id)
        {
            return _context.Orcamento.Any(e => e.orcamentoId == id);
        }
    }
}
