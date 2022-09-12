using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShopMVC.Services;

namespace PetShopMVC.Controllers
{ 
   
    public class ClientesController : Controller
    {
        private readonly ClienteService _clienteService;

        public ClientesController (ClienteService clienteService)
        {
            _clienteService = clienteService;
        }
    
    
        public IActionResult Index()

        {
            var list = _clienteService.FindAll();
            return View(list);
        }
    }
}