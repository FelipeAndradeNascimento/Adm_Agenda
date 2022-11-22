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
    public class AgendaController : Controller
    {
        private readonly Context_db _context;

        public AgendaController(Context_db context)
        {
            _context = context;
        }

        // GET: Agenda
        public async Task<IActionResult> Index()
        {
              return View(await _context.DbSetAgenda.ToListAsync());
        }

        // GET: Agenda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DbSetAgenda == null)
            {
                return NotFound();
            }

            var mdAgenda = await _context.DbSetAgenda
                .FirstOrDefaultAsync(m => m.IdAgenda == id);
            if (mdAgenda == null)
            {
                return NotFound();
            }

            return View(mdAgenda);
        }

        // GET: Agenda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agenda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAgenda,idContato,idTipo,dtCompromisso")] mdAgenda mdAgenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mdAgenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mdAgenda);
        }

        // GET: Agenda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DbSetAgenda == null)
            {
                return NotFound();
            }

            var mdAgenda = await _context.DbSetAgenda.FindAsync(id);
            if (mdAgenda == null)
            {
                return NotFound();
            }
            return View(mdAgenda);
        }

        // POST: Agenda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAgenda,idContato,idTipo,dtCompromisso")] mdAgenda mdAgenda)
        {
            if (id != mdAgenda.IdAgenda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mdAgenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!mdAgendaExists(mdAgenda.IdAgenda))
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
            return View(mdAgenda);
        }

        // GET: Agenda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DbSetAgenda == null)
            {
                return NotFound();
            }

            var mdAgenda = await _context.DbSetAgenda
                .FirstOrDefaultAsync(m => m.IdAgenda == id);
            if (mdAgenda == null)
            {
                return NotFound();
            }

            return View(mdAgenda);
        }

        // POST: Agenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DbSetAgenda == null)
            {
                return Problem("Entity set 'Context_db.DbSetAgenda'  is null.");
            }
            var mdAgenda = await _context.DbSetAgenda.FindAsync(id);
            if (mdAgenda != null)
            {
                _context.DbSetAgenda.Remove(mdAgenda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool mdAgendaExists(int id)
        {
          return _context.DbSetAgenda.Any(e => e.IdAgenda == id);
        }
    }
}
