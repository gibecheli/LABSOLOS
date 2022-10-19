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
    public class SolicitacoesController : Controller
    {
        private readonly Contexto _context;

        public SolicitacoesController(Contexto context)
        {
            _context = context;
        }

        // GET: Solicitacoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Solicitacoes.ToListAsync());
        }

        // GET: Solicitacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Solicitacoes == null)
            {
                return NotFound();
            }

            var solicitacao = await _context.Solicitacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (solicitacao == null)
            {
                return NotFound();
            }

            return View(solicitacao);
        }

        // GET: Solicitacoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Solicitacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,quantidade,dataEntrada,dataSaida,valor")] Solicitacao solicitacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(solicitacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(solicitacao);
        }

        // GET: Solicitacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Solicitacoes == null)
            {
                return NotFound();
            }

            var solicitacao = await _context.Solicitacoes.FindAsync(id);
            if (solicitacao == null)
            {
                return NotFound();
            }
            return View(solicitacao);
        }

        // POST: Solicitacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,quantidade,dataEntrada,dataSaida,valor")] Solicitacao solicitacao)
        {
            if (id != solicitacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solicitacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolicitacaoExists(solicitacao.Id))
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
            return View(solicitacao);
        }

        // GET: Solicitacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Solicitacoes == null)
            {
                return NotFound();
            }

            var solicitacao = await _context.Solicitacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (solicitacao == null)
            {
                return NotFound();
            }

            return View(solicitacao);
        }

        // POST: Solicitacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Solicitacoes == null)
            {
                return Problem("Entity set 'Contexto.Solicitacoes'  is null.");
            }
            var solicitacao = await _context.Solicitacoes.FindAsync(id);
            if (solicitacao != null)
            {
                _context.Solicitacoes.Remove(solicitacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SolicitacaoExists(int id)
        {
          return _context.Solicitacoes.Any(e => e.Id == id);
        }
    }
}
