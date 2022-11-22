using PetShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 

namespace PetShopMVC.Services
{
    public class ServicoService
    {
        private readonly PetShopMVCContext _context;

        public ServicoService(PetShopMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Servico>> FindAllAsync()
        {
            return await _context.Servico.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
