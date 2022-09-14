using PetShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopMVC.Services
{
    public class ClienteService
    {
        private readonly PetShopMVCContext _context;

        public ClienteService(PetShopMVCContext context)
        {
            _context = context;           
        }

        public List<Cliente> FindAll()
        {
            return _context.Cliente.ToList();
        }
        
        public void Insert(Cliente obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
    
}
