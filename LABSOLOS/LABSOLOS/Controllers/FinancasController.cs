using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LABSOLOS.Models;

namespace LABSOLOS.Controllers
{
    public class FinancasController : Controller
    {
        private readonly Contexto _context;

        public FinancasController(Contexto context)
        {
            _context = context;
        }

        // GET: Financas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Financas.ToListAsync());
        }

        // GET: Financas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Financas == null)
            {
                return NotFound();
            }

            var financeiro = await _context.Financas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (financeiro == null)
            {
                return NotFound();
            }

            return View(financeiro);
        }

        // GET: Financas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Financas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,valorTotal,formaPag,finalizado")] Financeiro financeiro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(financeiro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(financeiro);
        }

        // GET: Financas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Financas == null)
            {
                return NotFound();
            }

            var financeiro = await _context.Financas.FindAsync(id);
            if (financeiro == null)
            {
                return NotFound();
            }
            return View(financeiro);
        }

        // POST: Financas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,valorTotal,formaPag,finalizado")] Financeiro financeiro)
        {
            if (id != financeiro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(financeiro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinanceiroExists(financeiro.Id))
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
            return View(financeiro);
        }

        // GET: Financas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Financas == null)
            {
                return NotFound();
            }

            var financeiro = await _context.Financas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (financeiro == null)
            {
                return NotFound();
            }

            return View(financeiro);
        }

        // POST: Financas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Financas == null)
            {
                return Problem("Entity set 'Contexto.Financas'  is null.");
            }
            var financeiro = await _context.Financas.FindAsync(id);
            if (financeiro != null)
            {
                _context.Financas.Remove(financeiro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinanceiroExists(int id)
        {
          return _context.Financas.Any(e => e.Id == id);
        }
    }
}
