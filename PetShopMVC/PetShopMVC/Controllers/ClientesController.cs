using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShopMVC.Models;
using PetShopMVC.Models.ViewModels;
using PetShopMVC.Services;
using PetShopMVC.Services.Exceptions;

namespace PetShopMVC.Controllers
{

    public class ClientesController : Controller
    {
        private readonly ClienteService _clienteService;
        private readonly ServicoService _servicoService;

        public ClientesController(ClienteService clienteService, ServicoService servicoService)
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
            if (!ModelState.IsValid)
            {
                var Servicos = _servicoService.FindAll();
                var viewModel = new ClienteFormViewModel { Cliente = cliente, Servicos = Servicos };

                return View(viewModel);
            }

                _clienteService.Insert(cliente);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _clienteService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _clienteService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não não fornecido" });
            }

            var obj = _clienteService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe" });
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido" });
            }

            var obj = _clienteService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe" });
            }

            List<Servico> servicos = _servicoService.FindAll();
            ClienteFormViewModel viewModel = new ClienteFormViewModel { Cliente = obj, Servicos = servicos };
            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                var Servicos = _servicoService.FindAll();
                var viewModel = new ClienteFormViewModel { Cliente = cliente, Servicos = Servicos };

                return View(viewModel);
            }
            if (id != Cliente.id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não corresponde" });
            }
            try
            {
                _clienteService.Update(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e. Message });
            }
    
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}