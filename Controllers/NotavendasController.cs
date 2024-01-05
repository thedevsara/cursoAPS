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
    public class NotavendasController : Controller
    {
        private readonly MyDbContext _context;

        public NotavendasController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Notavendas
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Notavenda.Include(n => n.Item).Include(n => n.Pagamento);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Notavendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Notavenda == null)
            {
                return NotFound();
            }

            var notavenda = await _context.Notavenda
                .Include(n => n.Item)
                .Include(n => n.Pagamento)
                .FirstOrDefaultAsync(m => m.cod_nota == id);
            if (notavenda == null)
            {
                return NotFound();
            }

            return View(notavenda);
        }

        // GET: Notavendas/Create
        public IActionResult Create()
        {
            ViewData["Itemid"] = new SelectList(_context.items, "iditem", "iditem");
            ViewData["Pagamentoid"] = new SelectList(_context.Pagamento, "idpag", "idpag");
            return View();
        }

        // POST: Notavendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cod_nota,data,tipo,Pagamentoid,Itemid")] Notavenda notavenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notavenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Itemid"] = new SelectList(_context.items, "iditem", "iditem", notavenda.Itemid);
            ViewData["Pagamentoid"] = new SelectList(_context.Pagamento, "idpag", "idpag", notavenda.Pagamentoid);
            return View(notavenda);
        }

        // GET: Notavendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Notavenda == null)
            {
                return NotFound();
            }

            var notavenda = await _context.Notavenda.FindAsync(id);
            if (notavenda == null)
            {
                return NotFound();
            }
            ViewData["Itemid"] = new SelectList(_context.items, "iditem", "iditem", notavenda.Itemid);
            ViewData["Pagamentoid"] = new SelectList(_context.Pagamento, "idpag", "idpag", notavenda.Pagamentoid);
            return View(notavenda);
        }

        // POST: Notavendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cod_nota,data,tipo,Pagamentoid,Itemid")] Notavenda notavenda)
        {
            if (id != notavenda.cod_nota)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notavenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotavendaExists(notavenda.cod_nota))
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
            ViewData["Itemid"] = new SelectList(_context.items, "iditem", "iditem", notavenda.Itemid);
            ViewData["Pagamentoid"] = new SelectList(_context.Pagamento, "idpag", "idpag", notavenda.Pagamentoid);
            return View(notavenda);
        }

        // GET: Notavendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Notavenda == null)
            {
                return NotFound();
            }

            var notavenda = await _context.Notavenda
                .Include(n => n.Item)
                .Include(n => n.Pagamento)
                .FirstOrDefaultAsync(m => m.cod_nota == id);
            if (notavenda == null)
            {
                return NotFound();
            }

            return View(notavenda);
        }

        // POST: Notavendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Notavenda == null)
            {
                return Problem("Entity set 'MyDbContext.Notavenda'  is null.");
            }
            var notavenda = await _context.Notavenda.FindAsync(id);
            if (notavenda != null)
            {
                _context.Notavenda.Remove(notavenda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotavendaExists(int id)
        {
          return (_context.Notavenda?.Any(e => e.cod_nota == id)).GetValueOrDefault();
        }
    }
}
