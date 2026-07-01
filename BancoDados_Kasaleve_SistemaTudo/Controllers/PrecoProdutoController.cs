
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BancoDados_Kasaleve_SistemaTudo.Models;

public class PrecoProdutoController : Controller
{
    private readonly Contexto _context;

    public PrecoProdutoController(Contexto context)
    {
        _context = context;
    }

    // GET: PRECOPRODUTOS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.PrecoProduto.ToListAsync());
    }

    // GET: PRECOPRODUTOS/Details/5
    public async Task<IActionResult> Details(int? precoprodutoid)
    {
        if (precoprodutoid == null)
        {
            return NotFound();
        }

        var precoproduto = await _context.PrecoProduto
            .FirstOrDefaultAsync(m => m.PrecoProdutoId == precoprodutoid);
        if (precoproduto == null)
        {
            return NotFound();
        }

        return View(precoproduto);
    }

    // GET: PRECOPRODUTOS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PRECOPRODUTOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("PrecoProdutoId,ProdutoId,Produto,Valor,DataVigenciaInicio,DataVigenciaFim")] PrecoProduto precoproduto)
    {
        if (ModelState.IsValid)
        {
            _context.Add(precoproduto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(precoproduto);
    }

    // GET: PRECOPRODUTOS/Edit/5
    public async Task<IActionResult> Edit(int? precoprodutoid)
    {
        if (precoprodutoid == null)
        {
            return NotFound();
        }

        var precoproduto = await _context.PrecoProduto.FindAsync(precoprodutoid);
        if (precoproduto == null)
        {
            return NotFound();
        }
        return View(precoproduto);
    }

    // POST: PRECOPRODUTOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? precoprodutoid, [Bind("PrecoProdutoId,ProdutoId,Produto,Valor,DataVigenciaInicio,DataVigenciaFim")] PrecoProduto precoproduto)
    {
        if (precoprodutoid != precoproduto.PrecoProdutoId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(precoproduto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrecoProdutoExists(precoproduto.PrecoProdutoId))
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
        return View(precoproduto);
    }

    // GET: PRECOPRODUTOS/Delete/5
    public async Task<IActionResult> Delete(int? precoprodutoid)
    {
        if (precoprodutoid == null)
        {
            return NotFound();
        }

        var precoproduto = await _context.PrecoProduto
            .FirstOrDefaultAsync(m => m.PrecoProdutoId == precoprodutoid);
        if (precoproduto == null)
        {
            return NotFound();
        }

        return View(precoproduto);
    }

    // POST: PRECOPRODUTOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? precoprodutoid)
    {
        var precoproduto = await _context.PrecoProduto.FindAsync(precoprodutoid);
        if (precoproduto != null)
        {
            _context.PrecoProduto.Remove(precoproduto);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PrecoProdutoExists(int? precoprodutoid)
    {
        return _context.PrecoProduto.Any(e => e.PrecoProdutoId == precoprodutoid);
    }
}
