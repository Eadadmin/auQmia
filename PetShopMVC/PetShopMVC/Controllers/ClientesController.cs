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


        public async Task<IActionResult> Index()

        {
            var list = await _clienteService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var servicos = await _servicoService.FindAllAsync();
            var viewModel = new ClienteFormViewModel { Servicos = servicos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                var Servicos = await _servicoService.FindAllAsync();
                var viewModel = new ClienteFormViewModel { Cliente = cliente, Servicos = Servicos };

                return View(viewModel);
            }

                await _clienteService.InsertAsync(cliente);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _clienteService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _clienteService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não não fornecido" });
            }

            var obj = await _clienteService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido" });
            }

            var obj = await _clienteService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe" });
            }

            List<Servico> servicos = await _servicoService.FindAllAsync();
            ClienteFormViewModel viewModel = new ClienteFormViewModel { Cliente = obj, Servicos = servicos };
            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                var Servicos = await _servicoService.FindAllAsync();
                var viewModel = new ClienteFormViewModel { Cliente = cliente, Servicos = Servicos };

                return View(viewModel);
            }
            if (id != Cliente.id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não corresponde" });
            }
            try
            {
                await _clienteService.UpdateAsync(cliente);
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