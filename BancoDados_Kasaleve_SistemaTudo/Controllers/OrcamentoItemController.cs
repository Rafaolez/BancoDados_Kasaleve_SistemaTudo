
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BancoDados_Kasaleve_SistemaTudo.Models;

public class OrcamentoItemController : Controller
{
    private readonly Contexto _context;

    public OrcamentoItemController(Contexto context)
    {
        _context = context;
    }

    // GET: ORCAMENTOITEMS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.OrcamentoItem.ToListAsync());
    }

    // GET: ORCAMENTOITEMS/Details/5
    public async Task<IActionResult> Details(int? orcamentoitemid)
    {
        if (orcamentoitemid == null)
        {
            return NotFound();
        }

        var orcamentoitem = await _context.OrcamentoItem
            .FirstOrDefaultAsync(m => m.OrcamentoItemId == orcamentoitemid);
        if (orcamentoitem == null)
        {
            return NotFound();
        }

        return View(orcamentoitem);
    }

    // GET: ORCAMENTOITEMS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ORCAMENTOITEMS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("OrcamentoItemId,OrcamentoId,Orcamento,ProdutoId,Produto,Quantidade,ValorUnitario,DescricaoItem")] OrcamentoItem orcamentoitem)
    {
        if (ModelState.IsValid)
        {
            _context.Add(orcamentoitem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(orcamentoitem);
    }

    // GET: ORCAMENTOITEMS/Edit/5
    public async Task<IActionResult> Edit(int? orcamentoitemid)
    {
        if (orcamentoitemid == null)
        {
            return NotFound();
        }

        var orcamentoitem = await _context.OrcamentoItem.FindAsync(orcamentoitemid);
        if (orcamentoitem == null)
        {
            return NotFound();
        }
        return View(orcamentoitem);
    }

    // POST: ORCAMENTOITEMS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? orcamentoitemid, [Bind("OrcamentoItemId,OrcamentoId,Orcamento,ProdutoId,Produto,Quantidade,ValorUnitario,DescricaoItem")] OrcamentoItem orcamentoitem)
    {
        if (orcamentoitemid != orcamentoitem.OrcamentoItemId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(orcamentoitem);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrcamentoItemExists(orcamentoitem.OrcamentoItemId))
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
        return View(orcamentoitem);
    }

    // GET: ORCAMENTOITEMS/Delete/5
    public async Task<IActionResult> Delete(int? orcamentoitemid)
    {
        if (orcamentoitemid == null)
        {
            return NotFound();
        }

        var orcamentoitem = await _context.OrcamentoItem
            .FirstOrDefaultAsync(m => m.OrcamentoItemId == orcamentoitemid);
        if (orcamentoitem == null)
        {
            return NotFound();
        }

        return View(orcamentoitem);
    }

    // POST: ORCAMENTOITEMS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? orcamentoitemid)
    {
        var orcamentoitem = await _context.OrcamentoItem.FindAsync(orcamentoitemid);
        if (orcamentoitem != null)
        {
            _context.OrcamentoItem.Remove(orcamentoitem);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool OrcamentoItemExists(int? orcamentoitemid)
    {
        return _context.OrcamentoItem.Any(e => e.OrcamentoItemId == orcamentoitemid);
    }
}
