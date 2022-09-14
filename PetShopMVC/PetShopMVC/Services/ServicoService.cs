using PetShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopMVC.Services
{
    public class ServicoService
    {
        private readonly PetShopMVCContext _context;

        public ServicoService(PetShopMVCContext context)
        {
            _context = context;
        }

        public List<Servico> FindAll()
        {
            return _context.Servico.OrderBy(x => x.Name).ToList();
        }
    }
}
