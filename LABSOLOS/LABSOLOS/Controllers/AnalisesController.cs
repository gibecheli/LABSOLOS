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
    public class AnalisesController : Controller
    {
        private readonly Contexto _context;

        public AnalisesController(Contexto context)
        {
            _context = context;
        }

        // GET: Analises
        public async Task<IActionResult> Index()
        {
              return View(await _context.Analises.ToListAsync());
        }

        // GET: Analises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Analises == null)
            {
                return NotFound();
            }

            var analise = await _context.Analises
                .FirstOrDefaultAsync(m => m.id == id);
            if (analise == null)
            {
                return NotFound();
            }

            return View(analise);
        }

        // GET: Analises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Analises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,amostra,tipo,valor,descricao")] Analise analise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(analise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(analise);
        }

        // GET: Analises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Analises == null)
            {
                return NotFound();
            }

            var analise = await _context.Analises.FindAsync(id);
            if (analise == null)
            {
                return NotFound();
            }
            return View(analise);
        }

        // POST: Analises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,amostra,tipo,valor,descricao")] Analise analise)
        {
            if (id != analise.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(analise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnaliseExists(analise.id))
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
            return View(analise);
        }

        // GET: Analises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Analises == null)
            {
                return NotFound();
            }

            var analise = await _context.Analises
                .FirstOrDefaultAsync(m => m.id == id);
            if (analise == null)
            {
                return NotFound();
            }

            return View(analise);
        }

        // POST: Analises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Analises == null)
            {
                return Problem("Entity set 'Contexto.Analises'  is null.");
            }
            var analise = await _context.Analises.FindAsync(id);
            if (analise != null)
            {
                _context.Analises.Remove(analise);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnaliseExists(int id)
        {
          return _context.Analises.Any(e => e.id == id);
        }
    }
}
