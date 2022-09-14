using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShopMVC.Models;
using PetShopMVC.Models.ViewModels;
using PetShopMVC.Services;

namespace PetShopMVC.Controllers
{ 
   
    public class ClientesController : Controller
    {
        private readonly ClienteService _clienteService;
        private readonly ServicoService _servicoService;

        public ClientesController (ClienteService clienteService, ServicoService servicoService)
        {
            _clienteService = clienteService;
            _servicoService = servicoService;

        }
    
    
        public IActionResult Index()

        {
            var list = _clienteService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var servicos = _servicoService.FindAll();
            var viewModel = new ClienteFormViewModel { Servicos = servicos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente)
        {
            _clienteService.Insert(cliente);
            return RedirectToAction(nameof(Index));
        }


    }
}