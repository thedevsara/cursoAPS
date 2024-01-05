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
    public class TransportadorasController : Controller
    {
        private readonly MyDbContext _context;

        public TransportadorasController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Transportadoras
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.transportadoras.Include(t => t.notavenda);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Transportadoras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.transportadoras == null)
            {
                return NotFound();
            }

            var transportadora = await _context.transportadoras
                .Include(t => t.notavenda)
                .FirstOrDefaultAsync(m => m.idtrans == id);
            if (transportadora == null)
            {
                return NotFound();
            }

            return View(transportadora);
        }

        // GET: Transportadoras/Create
        public IActionResult Create()
        {
            ViewData["Notavendacod"] = new SelectList(_context.Notavenda, "cod_nota", "cod_nota");
            return View();
        }

        // POST: Transportadoras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idtrans,nome,Notavendacod")] Transportadora transportadora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transportadora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Notavendacod"] = new SelectList(_context.Notavenda, "cod_nota", "cod_nota", transportadora.Notavendacod);
            return View(transportadora);
        }

        // GET: Transportadoras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.transportadoras == null)
            {
                return NotFound();
            }

            var transportadora = await _context.transportadoras.FindAsync(id);
            if (transportadora == null)
            {
                return NotFound();
            }
            ViewData["Notavendacod"] = new SelectList(_context.Notavenda, "cod_nota", "cod_nota", transportadora.Notavendacod);
            return View(transportadora);
        }

        // POST: Transportadoras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idtrans,nome,Notavendacod")] Transportadora transportadora)
        {
            if (id != transportadora.idtrans)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transportadora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransportadoraExists(transportadora.idtrans))
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
            ViewData["Notavendacod"] = new SelectList(_context.Notavenda, "cod_nota", "cod_nota", transportadora.Notavendacod);
            return View(transportadora);
        }

        // GET: Transportadoras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.transportadoras == null)
            {
                return NotFound();
            }

            var transportadora = await _context.transportadoras
                .Include(t => t.notavenda)
                .FirstOrDefaultAsync(m => m.idtrans == id);
            if (transportadora == null)
            {
                return NotFound();
            }

            return View(transportadora);
        }

        // POST: Transportadoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.transportadoras == null)
            {
                return Problem("Entity set 'MyDbContext.transportadoras'  is null.");
            }
            var transportadora = await _context.transportadoras.FindAsync(id);
            if (transportadora != null)
            {
                _context.transportadoras.Remove(transportadora);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransportadoraExists(int id)
        {
          return (_context.transportadoras?.Any(e => e.idtrans == id)).GetValueOrDefault();
        }
    }
}
