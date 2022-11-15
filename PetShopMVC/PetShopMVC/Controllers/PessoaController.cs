using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShopMVC.Models;

namespace PetShopMVC.Controllers
{
    public class PessoaController : Controller
    {
        private readonly PetShopMVCContext _context;

        public PessoaController(PetShopMVCContext context)
        {
            _context = context;
        }

        // GET: Pessoa
        public async Task<IActionResult> Index()
        {
            var petShopMVCContext = _context.Customizar.Include(c => c.Servico);
            return View(await petShopMVCContext.ToListAsync());
        }

        // GET: Pessoa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customizar = await _context.Customizar
                .Include(c => c.Servico)
                .FirstOrDefaultAsync(m => m.CustomizarId == id);
            if (customizar == null)
            {
                return NotFound();
            }

            return View(customizar);
        }

        // GET: Pessoa/Create
        public IActionResult Create()
        {
            var list = _context.Servico.ToList();
            list.Add(new Servico { Id = 0, Name = "*Selecione um tipo de Servico" });
            list = list.OrderBy(c => c.Name).ToList();
            ViewData["ServicoId"] = new SelectList(list, "Id", "Name");
            return View();
        }

        // POST: Pessoa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CustomizarId,Name,Email,Telefone,Endereco,ServicoId")] Customizar customizar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customizar);

                try
                {
                    _context.SaveChanges();
                }
                catch (Exception)
                {


                }



                return RedirectToAction(nameof(Index));
            }
            ViewData["ServicoId"] = new SelectList(_context.Servico, "Id", "Name", customizar.ServicoId);
            return View(customizar);
        }

        // GET: Pessoa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customizar = await _context.Customizar.FindAsync(id);
            if (customizar == null)
            {
                return NotFound();
            }
            ViewData["ServicoId"] = new SelectList(_context.Servico, "Id", "Id", customizar.ServicoId);
            return View(customizar);
        }

        // POST: Pessoa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomizarId,Name,Email,Telefone,Endereco,ServicoId")] Customizar customizar)
        {
            if (id != customizar.CustomizarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customizar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomizarExists(customizar.CustomizarId))
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
            ViewData["ServicoId"] = new SelectList(_context.Servico, "Id", "Id", customizar.ServicoId);
            return View(customizar);
        }

        // GET: Pessoa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customizar = await _context.Customizar
                .Include(c => c.Servico)
                .FirstOrDefaultAsync(m => m.CustomizarId == id);
            if (customizar == null)
            {
                return NotFound();
            }

            return View(customizar);
        }

        // POST: Pessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customizar = await _context.Customizar.FindAsync(id);
            _context.Customizar.Remove(customizar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomizarExists(int id)
        {
            return _context.Customizar.Any(e => e.CustomizarId == id);
        }
    }
}
