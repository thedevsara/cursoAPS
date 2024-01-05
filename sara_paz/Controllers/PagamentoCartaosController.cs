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
    public class PagamentoCartaosController : Controller
    {
        private readonly MyDbContext _context;

        public PagamentoCartaosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: PagamentoCartaos
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Pagamentocartao.Include(p => p.Notavenda);
            return View(await myDbContext.ToListAsync());
        }

        // GET: PagamentoCartaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pagamentocartao == null)
            {
                return NotFound();
            }

            var pagamentoCartao = await _context.Pagamentocartao
                .Include(p => p.Notavenda)
                .FirstOrDefaultAsync(m => m.idtipo == id);
            if (pagamentoCartao == null)
            {
                return NotFound();
            }

            return View(pagamentoCartao);
        }

        // GET: PagamentoCartaos/Create
        public IActionResult Create()
        {
            ViewData["Notavendacod"] = new SelectList(_context.Notavenda, "cod_nota", "cod_nota");
            return View();
        }

        // POST: PagamentoCartaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("numerocart,bandeira,idtipo,nomecobrado,informacaoadicionais,Notavendacod")] PagamentoCartao pagamentoCartao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagamentoCartao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Notavendacod"] = new SelectList(_context.Notavenda, "cod_nota", "cod_nota", pagamentoCartao.Notavendacod);
            return View(pagamentoCartao);
        }

        // GET: PagamentoCartaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pagamentocartao == null)
            {
                return NotFound();
            }

            var pagamentoCartao = await _context.Pagamentocartao.FindAsync(id);
            if (pagamentoCartao == null)
            {
                return NotFound();
            }
            ViewData["Notavendacod"] = new SelectList(_context.Notavenda, "cod_nota", "cod_nota", pagamentoCartao.Notavendacod);
            return View(pagamentoCartao);
        }

        // POST: PagamentoCartaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("numerocart,bandeira,idtipo,nomecobrado,informacaoadicionais,Notavendacod")] PagamentoCartao pagamentoCartao)
        {
            if (id != pagamentoCartao.idtipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagamentoCartao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagamentoCartaoExists(pagamentoCartao.idtipo))
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
            ViewData["Notavendacod"] = new SelectList(_context.Notavenda, "cod_nota", "cod_nota", pagamentoCartao.Notavendacod);
            return View(pagamentoCartao);
        }

        // GET: PagamentoCartaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pagamentocartao == null)
            {
                return NotFound();
            }

            var pagamentoCartao = await _context.Pagamentocartao
                .Include(p => p.Notavenda)
                .FirstOrDefaultAsync(m => m.idtipo == id);
            if (pagamentoCartao == null)
            {
                return NotFound();
            }

            return View(pagamentoCartao);
        }

        // POST: PagamentoCartaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pagamentocartao == null)
            {
                return Problem("Entity set 'MyDbContext.Pagamentocartao'  is null.");
            }
            var pagamentoCartao = await _context.Pagamentocartao.FindAsync(id);
            if (pagamentoCartao != null)
            {
                _context.Pagamentocartao.Remove(pagamentoCartao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagamentoCartaoExists(int id)
        {
          return (_context.Pagamentocartao?.Any(e => e.idtipo == id)).GetValueOrDefault();
        }
    }
}
