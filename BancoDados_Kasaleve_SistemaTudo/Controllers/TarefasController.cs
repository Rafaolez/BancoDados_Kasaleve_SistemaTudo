
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BancoDados_Kasaleve_SistemaTudo.Models;

public class TarefasController : Controller
{
    private readonly Contexto _context;

    public TarefasController(Contexto context)
    {
        _context = context;
    }

    // GET: TAREFAS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Tarefa.ToListAsync());
    }

    // GET: TAREFAS/Details/5
    public async Task<IActionResult> Details(int? tarefaid)
    {
        if (tarefaid == null)
        {
            return NotFound();
        }

        var tarefa = await _context.Tarefa
            .FirstOrDefaultAsync(m => m.TarefaId == tarefaid);
        if (tarefa == null)
        {
            return NotFound();
        }

        return View(tarefa);
    }

    // GET: TAREFAS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: TAREFAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("TarefaId,Titulo,Descricao,DataVencimento,Status,Prioridade,UsuarioId,Usuario,DataCriacao")] Tarefa tarefa)
    {
        if (ModelState.IsValid)
        {
            _context.Add(tarefa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(tarefa);
    }

    // GET: TAREFAS/Edit/5
    public async Task<IActionResult> Edit(int? tarefaid)
    {
        if (tarefaid == null)
        {
            return NotFound();
        }

        var tarefa = await _context.Tarefa.FindAsync(tarefaid);
        if (tarefa == null)
        {
            return NotFound();
        }
        return View(tarefa);
    }

    // POST: TAREFAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? tarefaid, [Bind("TarefaId,Titulo,Descricao,DataVencimento,Status,Prioridade,UsuarioId,Usuario,DataCriacao")] Tarefa tarefa)
    {
        if (tarefaid != tarefa.TarefaId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(tarefa);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefaExists(tarefa.TarefaId))
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
        return View(tarefa);
    }

    // GET: TAREFAS/Delete/5
    public async Task<IActionResult> Delete(int? tarefaid)
    {
        if (tarefaid == null)
        {
            return NotFound();
        }

        var tarefa = await _context.Tarefa
            .FirstOrDefaultAsync(m => m.TarefaId == tarefaid);
        if (tarefa == null)
        {
            return NotFound();
        }

        return View(tarefa);
    }

    // POST: TAREFAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? tarefaid)
    {
        var tarefa = await _context.Tarefa.FindAsync(tarefaid);
        if (tarefa != null)
        {
            _context.Tarefa.Remove(tarefa);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TarefaExists(int? tarefaid)
    {
        return _context.Tarefa.Any(e => e.TarefaId == tarefaid);
    }
}
