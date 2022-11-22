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
    public class EnderecosController : Controller
    {
        private readonly Context_db _context;
        public EnderecosController(Context_db context)
        {
            _context = context;
        }

        // GET: Enderecos
        public async Task<IActionResult> Index()
        {
              return View(await _context.DbSetEndereco.ToListAsync());
        }

        // GET: Enderecos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DbSetEndereco == null)
            {
                return NotFound();
            }

            var mdEndereco = await _context.DbSetEndereco
                .FirstOrDefaultAsync(m => m.IdEndereco == id);
            if (mdEndereco == null)
            {
                return NotFound();
            }

            return View(mdEndereco);
        }

        // GET: Enderecos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enderecos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEndereco,Rua,Bairro,Cidade,Uf,Ibge,Cep")] mdEndereco mdEndereco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mdEndereco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mdEndereco);
        }

        // GET: Enderecos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DbSetEndereco == null)
            {
                return NotFound();
            }

            var mdEndereco = await _context.DbSetEndereco.FindAsync(id);
            if (mdEndereco == null)
            {
                return NotFound();
            }
            return View(mdEndereco);
        }

        // POST: Enderecos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEndereco,Rua,Bairro,Cidade,Uf,Ibge,Cep")] mdEndereco mdEndereco)
        {
            if (id != mdEndereco.IdEndereco)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mdEndereco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!mdEnderecoExists(mdEndereco.IdEndereco))
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
            return View(mdEndereco);
        }

        // GET: Enderecos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DbSetEndereco == null)
            {
                return NotFound();
            }

            var mdEndereco = await _context.DbSetEndereco
                .FirstOrDefaultAsync(m => m.IdEndereco == id);
            if (mdEndereco == null)
            {
                return NotFound();
            }

            return View(mdEndereco);
        }

        // POST: Enderecos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DbSetEndereco == null)
            {
                return Problem("Entity set 'Context_db.DbSetEndereco'  is null.");
            }
            var mdEndereco = await _context.DbSetEndereco.FindAsync(id);
            if (mdEndereco != null)
            {
                _context.DbSetEndereco.Remove(mdEndereco);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool mdEnderecoExists(int id)
        {
          return _context.DbSetEndereco.Any(e => e.IdEndereco == id);
        }
    }
}
