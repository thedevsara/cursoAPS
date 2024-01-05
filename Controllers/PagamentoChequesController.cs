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
    public class PagamentoChequesController : Controller
    {
        private readonly MyDbContext _context;

        public PagamentoChequesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: PagamentoCheques
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.PagamentoCheque.Include(p => p.Notavenda);
            return View(await myDbContext.ToListAsync());
        }

        // GET: PagamentoCheques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PagamentoCheque == null)
            {
                return NotFound();
            }

            var pagamentoCheque = await _context.PagamentoCheque
                .Include(p => p.Notavenda)
                .FirstOrDefaultAsync(m => m.idtipo == id);
            if (pagamentoCheque == null)
            {
                return NotFound();
            }

            return View(pagamentoCheque);
        }

        // GET: PagamentoCheques/Create
        public IActionResult Create()
        {
            ViewData["Notavendacod"] = new SelectList(_context.Notavenda, "cod_nota", "cod_nota");
            return View();
        }

        // POST: PagamentoCheques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("banco,nomebanco,idtipo,nomecobrado,informacaoadicionais,Notavendacod")] PagamentoCheque pagamentoCheque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagamentoCheque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Notavendacod"] = new SelectList(_context.Notavenda, "cod_nota", "cod_nota", pagamentoCheque.Notavendacod);
            return View(pagamentoCheque);
        }

        // GET: PagamentoCheques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PagamentoCheque == null)
            {
                return NotFound();
            }

            var pagamentoCheque = await _context.PagamentoCheque.FindAsync(id);
            if (pagamentoCheque == null)
            {
                return NotFound();
            }
            ViewData["Notavendacod"] = new SelectList(_context.Notavenda, "cod_nota", "cod_nota", pagamentoCheque.Notavendacod);
            return View(pagamentoCheque);
        }

        // POST: PagamentoCheques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("banco,nomebanco,idtipo,nomecobrado,informacaoadicionais,Notavendacod")] PagamentoCheque pagamentoCheque)
        {
            if (id != pagamentoCheque.idtipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagamentoCheque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagamentoChequeExists(pagamentoCheque.idtipo))
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
            ViewData["Notavendacod"] = new SelectList(_context.Notavenda, "cod_nota", "cod_nota", pagamentoCheque.Notavendacod);
            return View(pagamentoCheque);
        }

        // GET: PagamentoCheques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PagamentoCheque == null)
            {
                return NotFound();
            }

            var pagamentoCheque = await _context.PagamentoCheque
                .Include(p => p.Notavenda)
                .FirstOrDefaultAsync(m => m.idtipo == id);
            if (pagamentoCheque == null)
            {
                return NotFound();
            }

            return View(pagamentoCheque);
        }

        // POST: PagamentoCheques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PagamentoCheque == null)
            {
                return Problem("Entity set 'MyDbContext.PagamentoCheque'  is null.");
            }
            var pagamentoCheque = await _context.PagamentoCheque.FindAsync(id);
            if (pagamentoCheque != null)
            {
                _context.PagamentoCheque.Remove(pagamentoCheque);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagamentoChequeExists(int id)
        {
          return (_context.PagamentoCheque?.Any(e => e.idtipo == id)).GetValueOrDefault();
        }
    }
}
