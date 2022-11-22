using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Adm_Agenda.Data;
using Adm_Agenda.Models;

namespace Adm_Agenda.Controllers
{
    public class TipoCompromissosController : Controller
    {
        private readonly Context_db _context;

        public TipoCompromissosController(Context_db context)
        {
            _context = context;
        }

        // GET: TipoCompromissoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.DbSetTipoCompromisso.ToListAsync());
        }

        // GET: TipoCompromissoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DbSetTipoCompromisso == null)
            {
                return NotFound();
            }

            var mdTipoCompromisso = await _context.DbSetTipoCompromisso
                .FirstOrDefaultAsync(m => m.IdTipoCompromisso == id);
            if (mdTipoCompromisso == null)
            {
                return NotFound();
            }

            return View(mdTipoCompromisso);
        }

        // GET: TipoCompromissoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoCompromissoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoCompromisso,DescricaoTipo")] mdTipoCompromisso mdTipoCompromisso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mdTipoCompromisso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mdTipoCompromisso);
        }

        // GET: TipoCompromissoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DbSetTipoCompromisso == null)
            {
                return NotFound();
            }

            var mdTipoCompromisso = await _context.DbSetTipoCompromisso.FindAsync(id);
            if (mdTipoCompromisso == null)
            {
                return NotFound();
            }
            return View(mdTipoCompromisso);
        }

        // POST: TipoCompromissoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoCompromisso,DescricaoTipo")] mdTipoCompromisso mdTipoCompromisso)
        {
            if (id != mdTipoCompromisso.IdTipoCompromisso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mdTipoCompromisso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!mdTipoCompromissoExists(mdTipoCompromisso.IdTipoCompromisso))
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
            return View(mdTipoCompromisso);
        }

        // GET: TipoCompromissoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DbSetTipoCompromisso == null)
            {
                return NotFound();
            }

            var mdTipoCompromisso = await _context.DbSetTipoCompromisso
                .FirstOrDefaultAsync(m => m.IdTipoCompromisso == id);
            if (mdTipoCompromisso == null)
            {
                return NotFound();
            }

            return View(mdTipoCompromisso);
        }

        // POST: TipoCompromissoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DbSetTipoCompromisso == null)
            {
                return Problem("Entity set 'Context_db.DbSetTipoCompromisso'  is null.");
            }
            var mdTipoCompromisso = await _context.DbSetTipoCompromisso.FindAsync(id);
            if (mdTipoCompromisso != null)
            {
                _context.DbSetTipoCompromisso.Remove(mdTipoCompromisso);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool mdTipoCompromissoExists(int id)
        {
          return _context.DbSetTipoCompromisso.Any(e => e.IdTipoCompromisso == id);
        }
    }
}
