using PetShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace PetShopMVC.Services
{
    public class AgendamentoService
    {
        private readonly PetShopMVCContext _context;

        public AgendamentoService(PetShopMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Agendamento>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.Agendamento select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);

            }

            return await result
                .Include(x => x.Cliente)
                .Include(x => x.Cliente.Servico)
                .OrderByDescending(x => x.Date)
                .ToListAsync();

        }

        public async Task<List<IGrouping<Servico,Agendamento>>>FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.Agendamento select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);

            }

            return await result
                .Include(x => x.Cliente)
                .Include(x => x.Cliente.Servico)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Cliente.Servico)
                .ToListAsync();

        }
    }
}