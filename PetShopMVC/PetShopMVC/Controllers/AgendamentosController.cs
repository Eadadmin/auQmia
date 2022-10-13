using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShopMVC.Services;

namespace PetShopMVC.Controllers
{
    public class AgendamentosController : Controller
    {
        private readonly AgendamentoService _agendamentoService;

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            var result = await _agendamentoService.FindByDateAsync(minDate, maxDate);
            return View();
        }


        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}