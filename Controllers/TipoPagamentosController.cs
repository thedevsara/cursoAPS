using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sara_paz.Models;

namespace sara_paz.Controllers
{
    public class TipoPagamentosController : Controller
    {
        private readonly MyDbContext _context;

        public TipoPagamentosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: TipoPagamentos
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Tipopagamento.Include(t => t.Notavenda);
            return View(await myDbContext.ToListAsync());
        }

        // GET: TipoPagamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tipopagamento == null)
            {
                return NotFound();
            }

            var tipoPagamento = await _context.Tipopagamento
                .Include(t => t.Notavenda)
                .FirstOrDefaultAsync(m => m.idtipo == id);
            if (tipoPagamento == null)
            {
                return NotFound();
            }

            return View(tipoPagamento);
        }

        // GET: TipoPagamentos/Create
        public IActionResult Create()
        {
            ViewData["Notavendacod"] = new SelectList(_context.Notavenda, "cod_nota", "cod_nota");
            return View();
        }

        // POST: TipoPagamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idtipo,nomecobrado,informacaoadicionais,Notavendacod")] TipoPagamento tipoPagamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoPagamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Notavendacod"] = new SelectList(_context.Notavenda, "cod_nota", "cod_nota", tipoPagamento.Notavendacod);
            return View(tipoPagamento);
        }

        // GET: TipoPagamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tipopagamento == null)
            {
                return NotFound();
            }

            var tipoPagamento = await _context.Tipopagamento.FindAsync(id);
            if (tipoPagamento == null)
            {
                return NotFound();
            }
            ViewData["Notavendacod"] = new SelectList(_context.Notavenda, "cod_nota", "cod_nota", tipoPagamento.Notavendacod);
            return View(tipoPagamento);
        }

        // POST: TipoPagamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idtipo,nomecobrado,informacaoadicionais,Notavendacod")] TipoPagamento tipoPagamento)
        {
            if (id != tipoPagamento.idtipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoPagamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPagamentoExists(tipoPagamento.idtipo))
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
            ViewData["Notavendacod"] = new SelectList(_context.Notavenda, "cod_nota", "cod_nota", tipoPagamento.Notavendacod);
            return View(tipoPagamento);
        }

        // GET: TipoPagamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tipopagamento == null)
            {
                return NotFound();
            }

            var tipoPagamento = await _context.Tipopagamento
                .Include(t => t.Notavenda)
                .FirstOrDefaultAsync(m => m.idtipo == id);
            if (tipoPagamento == null)
            {
                return NotFound();
            }

            return View(tipoPagamento);
        }

        // POST: TipoPagamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tipopagamento == null)
            {
                return Problem("Entity set 'MyDbContext.Tipopagamento'  is null.");
            }
            var tipoPagamento = await _context.Tipopagamento.FindAsync(id);
            if (tipoPagamento != null)
            {
                _context.Tipopagamento.Remove(tipoPagamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPagamentoExists(int id)
        {
          return (_context.Tipopagamento?.Any(e => e.idtipo == id)).GetValueOrDefault();
        }
    }
}
