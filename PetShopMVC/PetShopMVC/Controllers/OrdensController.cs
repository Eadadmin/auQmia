using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetShopMVC.Models;
using PetShopMVC.Models.ViewModels;
using PetShopMVC.Services;
using System.Web;

namespace PetShopMVC.Controllers
{
    public class OrdensController : Controller
    {

        // private PetShopMVCContext _context = new PetShopMVCContext();


        private readonly PetShopMVCContext _context;

        public OrdensController(PetShopMVCContext context)
        {
            _context = context;
        }


        public IActionResult NovaOrdem()
        {

            var ordemView = new OrdemView();
            ordemView.Customizar = new Customizar();
            ordemView.ServicoOrdem = new List<ServicoOrdem>();


            var list = _context.Customizar.ToList();
            list.Add(new Customizar { CustomizarId = 0, Name = "[Selecione um cliente!]" });
            list = list.OrderBy(c => c.Name).ToList();
            ViewData["CustomizarId"] = new SelectList(list, "CustomizarId", "Name");

            return View(ordemView);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NovaOrdem(OrdemView ordemView)

        {
            return View(ordemView);
        }


        public IActionResult AddServico(ServicoOrdem servicoOrdem)
        {

            var list = _context.Servico.ToList();
            list.Add(new ServicoOrdem { Id = 0, Name = "[Selecione um Servico!]" });
            list = list.OrderBy(c => c.Id).ToList();
            ViewData["Id"] = new SelectList(list, "Id", "Name");
            return View(servicoOrdem);
        }
            
      


        
           
       






    }
}