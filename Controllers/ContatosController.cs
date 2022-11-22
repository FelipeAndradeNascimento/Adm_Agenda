using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Adm_Agenda.Data;
using Adm_Agenda.Models;
using Adm_Agenda.Regras;
using Adm_Agenda.ViewModel;

namespace Adm_Agenda.Controllers
{
    public class ContatosController : Controller
    {
        private readonly Context_db _context;

        public ContatosController(Context_db context)
        {
            _context = context;
        }

        // GET: Contatos
        public async Task<IActionResult> Index()
        {
              return View(await _context.DbSetContatos.ToListAsync());
        }

        // GET: Contatos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DbSetContatos == null)
            {
                return NotFound();
            }

            var mdContatos = await _context.DbSetContatos
                .FirstOrDefaultAsync(m => m.IdContato == id);
            if (mdContatos == null)
            {
                return NotFound();
            }

            return View(mdContatos);
        }

        // GET: Contatos/Create
        public IActionResult Create()
        {
            /*
            clsDadosEndereco objRegras = new clsDadosEndereco();
            List<mdEndereco> lista_enderecos = new List<mdEndereco>();
            lista_enderecos = objRegras.retornaEnderecos();

            ViewData["listaEndereco"] = new SelectList(lista_enderecos, "IdEndereco", "Rua");
            */
            var modelEnd = new ContatoViewModel();
            return View(modelEnd);
        }

        // POST: Contatos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdContato,Nome,Email,Telefone,IdEndereco")] mdContatos mdContatos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mdContatos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mdContatos);
        }

        // GET: Contatos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DbSetContatos == null)
            {
                return NotFound();
            }

            var mdContatos = await _context.DbSetContatos.FindAsync(id);
            if (mdContatos == null)
            {
                return NotFound();
            }
            return View(mdContatos);
        }

        // POST: Contatos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdContato,Nome,Email,Telefone,IdEndereco")] mdContatos mdContatos)
        {
            if (id != mdContatos.IdContato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mdContatos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!mdContatosExists(mdContatos.IdContato))
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
            return View(mdContatos);
        }

        // GET: Contatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DbSetContatos == null)
            {
                return NotFound();
            }

            var mdContatos = await _context.DbSetContatos
                .FirstOrDefaultAsync(m => m.IdContato == id);
            if (mdContatos == null)
            {
                return NotFound();
            }

            return View(mdContatos);
        }

        // POST: Contatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DbSetContatos == null)
            {
                return Problem("Entity set 'Context_db.DbSetContatos'  is null.");
            }
            var mdContatos = await _context.DbSetContatos.FindAsync(id);
            if (mdContatos != null)
            {
                _context.DbSetContatos.Remove(mdContatos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool mdContatosExists(int id)
        {
          return _context.DbSetContatos.Any(e => e.IdContato == id);
        }
    }
}
